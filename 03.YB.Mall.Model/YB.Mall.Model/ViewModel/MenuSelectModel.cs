using System.Collections.Generic;

namespace YB.Mall.Model.ViewModel
{
    public class MenuSelectModel
    {
        public IEnumerable<TreeGridModel> rows { get; set; }
    }
    /// <summary>
    /// 折叠列表 模型
    /// </summary>
    public class TreeGridModel : MenuViewModel
    {
        public TreeGridModel()
        {
            this.level = 0;
            this.isLeaf = false;
            this.parent = "0";
            this.expanded = true;
            this.loaded = true;
        }
        public int level { get; set; }
        public string parent { get; set; }
        public bool isLeaf { get; set; }
        public bool expanded { get; set; }
        public bool loaded { get; set; }
    }
    /// <summary>
    /// 下拉 模型
    /// </summary>
    public class TreeSelectModel
    {
        public TreeSelectModel()
        {
            parentId = 0;
        }
        public int id { get; set; }
        public string text { get; set; }
        public int parentId { get; set; }
        public object data { get; set; }
    }
    /// <summary>
    /// 折叠树 模型
    /// </summary>
    public class TreeViewModel
    {
        public TreeViewModel()
        {
            showcheck = true;
            isexpand = true;
            complete = true;
            hasChildren = true;
            this.ChildNodes=new List<TreeViewModel>();
        }
        public string parentnodes { get; set; }
        public string id { get; set; }
        public string text { get; set; }
        public string value { get; set; }
        public int? checkstate { get; set; }
        public bool showcheck { get; set; }
        public bool complete { get; set; }
        public bool isexpand { get; set; }
        public bool hasChildren { get; set; }
        public string img { get; set; }
        public ICollection<TreeViewModel> ChildNodes { get; set; }
    }
}