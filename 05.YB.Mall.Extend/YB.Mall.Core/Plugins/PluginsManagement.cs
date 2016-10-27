
using YB.Mall.Core.ExtendException;

namespace YB.Mall.Core.Plugins
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using YB.Mall.Extend.Helper;
    using YB.Mall.Extend.Log;
    public static class PluginsManagement
    {
        #region 内部成员

        /// <summary>
        /// 已安装插件
        /// </summary>
        static readonly Dictionary<PluginType, List<PluginInfo>> IntalledPlugins = new Dictionary<PluginType, List<PluginInfo>>();//此处可以考虑放到缓存中,否则多Web下会存在问题

        /// <summary>
        /// 标记是否已经在创建时加载
        /// </summary>
        static bool _registed = false;

        static PluginsManagement()
        {
            //初始化intalledPlugins
            foreach (var value in Enum.GetValues(typeof(PluginType)))
            {
                IntalledPlugins.Add((PluginType)value, new List<PluginInfo>());
            }
        }

        #endregion

        #region 获取已安装的插件信息

        /// <summary>
        /// 获取已安装的插件信息
        /// </summary>
        /// <param name="pluginType">插件类型</param>
        /// <returns></returns>
        public static IEnumerable<PluginInfo> GetInstalledPluginInfos(PluginType pluginType)
        {
            var plugins = IntalledPlugins[pluginType].Select(DeepClone);
            return plugins;
        }

        #endregion

        #region 获取指定的插件信息

        /// <summary>
        /// 获取指定的插件信息
        /// </summary>
        /// <param name="pluginId">插件标识</param>
        /// <returns></returns>
        public static PluginInfo GetPluginInfo(string pluginId)
        {
            PluginInfo pluginfo = null;
            foreach (var plugins in IntalledPlugins.Values)
            {
                pluginfo = plugins.FirstOrDefault(item => item.PluginId == pluginId.Trim());
                if (pluginfo != null)
                    break;
            }
            return pluginfo;
        }

        #endregion

        #region 获取已安装插件

        /// <summary>
        /// 获取已安装的插件
        /// </summary>
        /// <param name="pluginType">插件类型</param>
        /// <returns></returns>
        public static IEnumerable<T> GetInstalledPlugins<T>(PluginType pluginType) where T : IPlugin
        {
            var pluginInfos = GetInstalledPluginInfos(pluginType);
            var enumerable = pluginInfos as PluginInfo[] ?? pluginInfos.ToArray();
            var plugins = new T[enumerable.Count()];
            var i = 0;
            foreach (var pluginInfo in enumerable)
            {
                plugins[i++] = Core.Instance.Get<T>(pluginInfo.ClassFullName);
            }
            return plugins;
        }





        #endregion

        #region 获取已安装插件

        /// <summary>
        /// 获取已安装的插件
        /// </summary>
        /// <param name="pluginId"></param>
        /// <returns></returns>
        public static T GetInstalledPlugin<T>(string pluginId) where T : IPlugin
        {
            var plugin = default(T);
            var pluginInfo = GetPluginInfo(pluginId);
            if (pluginInfo != null)
                plugin = Instance.Get<T>(pluginInfo.ClassFullName);
            return plugin;
        }

        #endregion

        #region 加载指定目录下的所有DLL

        /// <summary>
        /// 加载指定目录下所有dll
        /// </summary>
        public static void RegistAtStart()
        {
            if (_registed) return;
            _registed = true;
            var list = GetPluginFiles(IoHelper.GetMapPath("/Plugins")).ToList<string>();
            foreach (var assembly in list.Select(InstallDll))
            {

            }
        }

        #endregion

        #region 开启插件

        /// <summary>
        /// 开启插件
        /// </summary>
        /// <param name="pluginId">插件标识</param>
        /// <param name="enable">是否开启</param>
        public static void EnablePlugin_Private(string pluginId, bool enable)
        {
            var plugInfo = GetPluginInfo(pluginId);
            if (plugInfo == null)
                throw new PluginNotFoundException(pluginId);
            plugInfo.Enable = enable;
            //序列化,将插件信息保存到系统插件配置文件中
            XmlHelper.SerializeToXml(plugInfo, IoHelper.GetMapPath("/Plugins/configs/") + pluginId + ".config");
        }

        #endregion

        #region 安装插件

        /// <summary>
        /// 安装插件
        /// </summary>
        /// <param name="pluginFullDirectory"></param>
        public static void InstallPlugin(string pluginFullDirectory)
        {
            var dllFiles = GetPluginFiles(pluginFullDirectory);
            foreach (var dllFileName in dllFiles)
            {
                try
                {
                    InstallDll(dllFileName);
                }
                catch (Exception ex)
                {
                    Log.Error("插件安装失败(" + dllFileName + ")", ex);
                }
            }
        }

        #endregion

        #region 卸载插件

        /// <summary>
        /// 卸载插件
        /// </summary>
        /// <param name="classFullName"></param>
        public static void UnInstallPlugin(string classFullName)
        {
            var allPlugins = new List<PluginInfo>();
            foreach (var pluginsList in IntalledPlugins.Values)
            {
                allPlugins.AddRange(pluginsList);
            }
            var pluginInfo = allPlugins.FirstOrDefault(item => item.ClassFullName == classFullName);
            if (pluginInfo == null)
                Log.Warn(string.Format("卸载插件{0}时没有找到插件信息", classFullName));
            else
            {
                foreach (var pluginType in pluginInfo.PluginTypes)
                    IntalledPlugins[pluginType].Remove(pluginInfo);//从已安装列表中移除该插件
                try
                {
                    Directory.Delete(pluginInfo.PluginDirectory, true);
                }
                catch
                {
                    Log.Warn(string.Format("移除插件{0}时没有找到对应的插件目录", pluginInfo.PluginId));
                }
            }
        }

        #endregion

        #region 获取插件



        /// <summary>
        /// 获取指定id的插件
        /// </summary>
        /// <typeparam name="T">插件类型</typeparam>
        /// <param name="pluginId">插件Id</param>
        /// <returns></returns>
        public static Plugin<T> GetPlugin<T>(string pluginId) where T : IPlugin
        {
            var pluginInfo = GetPluginInfo(pluginId);
            Plugin<T> plugin = new Plugin<T>()
            {
                PluginInfo = pluginInfo,
                Biz = Instance.Get<T>(pluginInfo.ClassFullName)
            };
            return plugin;
        }

        /// <summary>
        /// 开启插件
        /// </summary>
        /// <param name="pluginId">插件Id</param>
        /// <param name="enable">是否开启</param>
        public static void EnablePlugin(string pluginId, bool enable)
        {
            try
            {
                var plugin = GetPlugin<IPlugin>(pluginId);
                if (enable)//检查是否可以开启
                    plugin.Biz.CheckCanEnable();
                EnablePlugin_Private(pluginId, enable);
            }
            catch
            {
                throw;
            }
        }


        public static void UninstallPlugin(string pluginId)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region 内部方法

        /// <summary>
        /// 加载(安装)dll 
        /// </summary>
        /// <param name="dllFileName"></param>
        /// <returns></returns>
        static Assembly InstallDll(string dllFileName)
        {
            string newFileName = dllFileName;
            FileInfo fileInfo = new FileInfo(dllFileName);
            DirectoryInfo copyFolder;
            if (!string.IsNullOrWhiteSpace(AppDomain.CurrentDomain.DynamicDirectory))
            {
                //获取asp.net dll运行目录
                copyFolder = new DirectoryInfo(AppDomain.CurrentDomain.DynamicDirectory);
            }
            else
                copyFolder = new DirectoryInfo(IoHelper.GetMapPath(""));
            newFileName = copyFolder.FullName + "\\" + fileInfo.Name;

            Assembly assembly = null;
            PluginInfo pluginfo = null;
            try
            {
                System.IO.File.Copy(dllFileName, newFileName, true);
                assembly = Assembly.Load(AssemblyName.GetAssemblyName(newFileName));
                if (assembly.FullName.StartsWith("YB.Mall.Plugin"))
                {
                    pluginfo = AddPluginInfo(fileInfo);//添加插件信息
                    //向插件注入信息
                    var plugin = Core.Instance.Get<IPlugin>(pluginfo.ClassFullName);
                    plugin.WorkDirectory = fileInfo.Directory.FullName;

                }
            }
            catch (IOException ex)
            {
                Log.Error("插件复制失败(" + dllFileName + ")！", ex);
                if (pluginfo != null)//插件复制失败时，移除插件安装信息
                    RemovePlugin(pluginfo);
            }
            catch (Exception ex)
            {
                Log.Error("插件加载失败(" + dllFileName + ")！", ex);
                if (pluginfo != null)//插件加载失败时，移除插件安装信息
                    RemovePlugin(pluginfo);
            }
            return assembly;
        }

        /// <summary>
        /// 添加插件信息
        /// </summary>
        /// <param name="dllFile"></param>
        static PluginInfo AddPluginInfo(FileInfo dllFile)
        {
            PluginInfo pluginInfo;
            var pluginId = dllFile.Name.Replace(".dll", "");
            string installedConfigPath = IoHelper.GetMapPath("/Plugins/configs/") + pluginId + ".config";
            if (!File.Exists(installedConfigPath))//检查是否已经安装过
            {//未安装过

                //查找插件自带的配置文件
                FileInfo[] configFiles = dllFile.Directory.GetFiles("plugin.config", SearchOption.TopDirectoryOnly);
                if (configFiles.Length > 0)
                {
                    //读取插件自带的配置信息
                    pluginInfo = (PluginInfo)XmlHelper.DeserializeFromXML(typeof(PluginInfo), configFiles[0].FullName);
                    //使用程序集名称为插件唯一标识
                    pluginInfo.PluginId = pluginId;
                    //记录插件所在目录
                    pluginInfo.PluginDirectory = dllFile.Directory.FullName;
                    //更新插件时间
                    pluginInfo.AddedTime = DateTime.Now;
                    //序列化,将插件信息保存到系统插件配置文件中
                    XmlHelper.SerializeToXml(pluginInfo, installedConfigPath);
                }
                else
                    throw new FileNotFoundException("未找到插件" + pluginId + "的配置文件");
            }
            else
            {//读取系统插件配置文件中的配置信息
                pluginInfo = (PluginInfo)XmlHelper.DeserializeFromXML(typeof(PluginInfo), installedConfigPath);
            }

            //将插件信息保存至内存插件列表中
            UpdatePluginList(pluginInfo);

            return pluginInfo;
        }


        /// <summary>
        /// 更新插件列表
        /// </summary>
        /// <param name="plugin"></param>
        static void UpdatePluginList(PluginInfo plugin)
        {
            foreach (var pluginType in plugin.PluginTypes)
                IntalledPlugins[pluginType].Add(plugin);
        }

        static void RemovePlugin(PluginInfo plugin)
        {
            foreach (var pluginType in plugin.PluginTypes)
                IntalledPlugins[pluginType].Remove(plugin);
        }

        /// <summary>
        /// 获取插件程序集文件
        /// </summary>
        /// <param name="pluginDirectory">插件所在目录</param>
        /// <returns></returns>
        static IEnumerable<string> GetPluginFiles(string pluginDirectory)
        {
            if (!Directory.Exists(pluginDirectory))
                Directory.CreateDirectory(pluginDirectory);
            //搜索当前目录(包括子目录)下所有dll文件
            var dllFiles = Directory.GetFiles(pluginDirectory, "*.dll", SearchOption.AllDirectories);
            return dllFiles;
        }

        /// <summary>
        /// 深复制IPlugin
        /// </summary>
        /// <param name="plugin"></param>
        /// <returns></returns>
        static PluginInfo DeepClone(PluginInfo plugin)
        {
            string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(plugin);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<PluginInfo>(jsonString);
        }

        #endregion
    }
    public class RegistAtStart
    {
        public static void Regist()
        {
            PluginsManagement.RegistAtStart();
        }
    }
}

