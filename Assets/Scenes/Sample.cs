using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour
{
    private readonly List<(int, string)> data = new();

    private void Start()
    {
        foreach (var columns in CsvReader("master"))
        {
            //④各要素を適宜変換してListに追加
            data.Add((int.Parse(columns[0]), columns[1]));
        }

        foreach (var reslut in data)
        {
            Debug.Log(reslut);
        }

    }

    private static IEnumerable<string[]> CsvReader(string assetName)
    {
        //①csvファイルをTextAssetとして読み込み、StringReaderに格納する
        TextAsset textAsset = Resources.Load<TextAsset>(assetName);
        using var stringReader = new StringReader(textAsset.text);

        var row = stringReader.ReadLine(); //一行読み込み

        //②全ての行をReadLineするまで
        while (row != null)
        {
            //③カンマで区切り、文字配列とする
            var columns = row.Split(',');

            //foreachブロックに文字配列を投げる
            yield return columns;

            row = stringReader.ReadLine(); //一行読み込み
        }
    }

}
