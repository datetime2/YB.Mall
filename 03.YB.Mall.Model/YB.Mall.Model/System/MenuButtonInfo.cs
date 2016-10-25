using System.Collections.Generic;

namespace YB.Mall.Model
{
    public class MenuButtonInfo
    {
        public int ButtonId { get; set; }
        public int MenuId { get; set; }
        public string ButtonName { get; set; }
        public string ElementId { get; set; }
        public string Icon { get; set; }
        public string Event { get; set; }
        public int Sort { get; set; }
        public bool IsEnabled { get; set; }
        /// <summary>
        /// 按钮位置
        /// </summary>
        public int Location { get; set; }
        public virtual MenuInfo MenuInfo { get; set; }
    }
}