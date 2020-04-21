using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AutoGeneratorTile : MonoBehaviour {

    [Header("Value")]
    public Tilemap tilemap;
    public Tile dirt;
    public Tile grass;
    public GameObject tree;

    //value
    string path;
    int x_length;
    int y_length;
    Data data;

    void Start() {
        path = @"Assets/Data/data.json";
        x_length = 0;
        y_length = 0;

        data = ReadJsonFile(path);

        //生成草地树木
        foreach (Tree t in data.treeList) {
            Vector3Int v = new Vector3Int(t.x, t.y, 0);
            Vector3 v2 = tilemap.CellToWorld(v);
            tilemap.SetTile(v, dirt);
            Instantiate(tree, v2, Quaternion.identity);

            if (t.x > x_length)
                x_length = t.x;

            if (t.y > y_length)
                y_length = t.y;
        }

        x_length++;
        y_length++;

        //生成泥土
        for (int x = 0; x <= x_length; x++) {
            for (int y = 0; y <= y_length; y++) {
                Vector3Int v = new Vector3Int(x, y, 0);
                if (tilemap.GetTile(v) == null) {
                    tilemap.SetTile(v, grass);
                }
            }
        }

        // if (Input.GetKeyDown("a")) {
        //     Data data = new Data();
        //     data.name = "test";
        //     data.treeList.Add(new Tree() { id = 1, x = 1, y = 1, outcome = false });
        //     data.treeList.Add(new Tree() { id = 2, x = 2, y = 2, outcome = false });
        //     data.treeList.Add(new Tree() { id = 3, x = 3, y = 3, outcome = false });
        //     WriteJsonFile(data, path);
        // }

        // Vector3Int tilePos = tilemap.WorldToCell(Input.mousePosition);

        // if (Input.GetMouseButton(0)) {
        //     Debug.Log(tilePos);
        //     Debug.Log(tilemap.GetTile(tilePos));
        //     if (tilemap.GetTile(tilePos) != null) {
        //         tilemap.SetTile(tilePos, replaceTile);
        //     }
        // }
    }

    void WriteJsonFile(Data data, string path) {
        string json = JsonUtility.ToJson(data);

        using(FileStream fs = File.Create(path)) {
            byte[] info = new UTF8Encoding(true).GetBytes(json);
            fs.Write(info, 0, info.Length);
        }
    }

    Data ReadJsonFile(string path) {
        string json = "";

        using(FileStream fs = File.OpenRead(path)) {
            byte[] b = new byte[1024];
            UTF8Encoding temp = new UTF8Encoding(true);
            while (fs.Read(b, 0, b.Length) > 0) {
                json += temp.GetString(b);
            }
        }

        return JsonUtility.FromJson<Data>(json);
    }

    [Serializable]
    class Data {
        public string name;
        public List<Tree> treeList = new List<Tree>();
    }

    [Serializable]
    class Tree {
        public int id;
        public int x;
        public int y;
        public bool outcome;
    }
}