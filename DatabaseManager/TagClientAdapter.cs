﻿using DatabaseManager.TagServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManager
{
    public class TagClientAdapter
    {
        private readonly TagServiceClient TagClient;

        public TagClientAdapter(TagServiceClient tagClient)
        {
            TagClient = tagClient;
        }

        public void AddTag()
        {
            TagClient.AddTag();
        }

        public void RemoveTag()
        {
            TagClient.RemoveTag(12.454);
        }
    }
}
