using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMEEInExcel.Model
{
    class DataCategory
    {
        public string Uid;
        public DataItem[] item;
//        public bool Deprecated;
//        public Environment Environment;
        public string Created;
        public string Name;
        public string Path;
        public ItemDefinition ItemDefinition;
        public string Modified;
        public string WikiName;

        public string FullPath;
        public string ParentUid;
        public string ParentWikiName;
        public string Authority;
        public string History;
        public string Provenance;

    }
}

