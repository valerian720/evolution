using System;
using System.Collections.Generic;
using Godot;

namespace evolution.Core.Util
{
    public static class PrefabHelper
    {
        public static Dictionary<string, PackedScene> LoadPrefabsDictionary(string path, string[] namesToExclude = null)
        {
            var dict = new Dictionary<string, PackedScene>();
            var dir = new Directory();

            if (dir.Open(path) == Error.Ok)
            {
                dir.ListDirBegin();
                var filename = dir.GetNext();

                while (!string.IsNullOrEmpty(filename))
                {
                    if (dir.CurrentIsDir())
                    {
                        filename = dir.GetNext();
                        continue;
                    }

                    var filenameWOExtension = System.IO.Path.GetFileNameWithoutExtension(filename);

                    if (namesToExclude != null && Array.IndexOf(namesToExclude, filenameWOExtension) > -1)
                    {
                        filename = dir.GetNext();
                        continue;
                    }

                    var scene = GD.Load<PackedScene>($"{path}/{filename}");
                    dict.Add(filenameWOExtension, scene);

                    filename = dir.GetNext();
                }
            }

            return dict;
        }

        public static List<PackedScene> LoadPrefabsList(string path)
        {
            var list = new List<PackedScene>();
            var dir = new Directory();

            if (dir.Open(path) == Error.Ok)
            {
                dir.ListDirBegin();
                var filename = dir.GetNext();

                while (!string.IsNullOrEmpty(filename))
                {
                    if (dir.CurrentIsDir())
                    {
                        filename = dir.GetNext();
                        continue;
                    }

                    var scene = GD.Load<PackedScene>($"{path}/{filename}");
                    list.Add(scene);

                    filename = dir.GetNext();
                }
            }

            return list;
        }
    }
}
