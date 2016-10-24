using System.Collections.Generic;

namespace YB.Mall.Model.ViewModel
{
    public class MenuSelectModel
    {
        public IEnumerable<TreeGridModel> rows { get; set; }
    }
    public class TreeGridModel : MenuViewModel
    {
        public TreeGridModel()
        {
            this.level = 0;
            this.isLeaf = false;
            this.parent = "0";
            this.expanded = false;
            this.loaded = true;
        }
        public int level { get; set; }
        public string parent { get; set; }
        public bool isLeaf { get; set; }
        public bool expanded { get; set; }
        public bool loaded { get; set; }
    }

    public class TreeSelectModel
    {
        public int id { get; set; }
        public string text { get; set; }
        public int parentId { get; set; }
        public object data { get; set; }
    }
}