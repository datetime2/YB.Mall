using System.Collections.Generic;

namespace YB.Mall.Model.ViewModel
{
    public class MenuSelectModel:MenuViewModel
    {
        public IEnumerable<TreeSelectModel> rows { get; set; }
    }
    public class TreeSelectModel : MenuViewModel
    {
        public TreeSelectModel()
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
}