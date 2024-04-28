﻿using System.Collections.Generic;
using System.Linq;

namespace EbMasterData.Editor
{
    public class ConvertEnums
    {
        private readonly Settings settings;

        public ConvertEnums(Settings settings)
        {
            this.settings = settings;
        }

        public List<string> CreateMasterDataEnums(List<ReaderForEditor.EnumData> enumData)
        {
            var res = new List<string>
            {
                $"// Auto create by EbMasterData.ConvertEnums",
                $"namespace {settings.NamespaceName}",
                $"{{",
            };

            for (int i = 0; i < enumData.Count; i++)
            {
                if (i > 0) res.Add("");

                var v = enumData[i];
                res.AddRange(new List<string>
                {
                    $"    public enum {v.name}",
                    $"    {{",
                });

                res.AddRange(v.values.Select(v => $"        {v},"));

                res.AddRange(new List<string>
                {
                    $"    }}",
                });
            }

            res.AddRange(new List<string>
            {
                $"}}",
                $"",
            });

            return res;
        }
    }
}
