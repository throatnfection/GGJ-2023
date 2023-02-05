using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rng : MonoBehaviour
{
    int chosenTask;
    float counterTask1;
    float counterTask2;
    float timer;
    float timer2;
    int maxX = 10;
    int maxY = 10;
    public List<Tiles> X = new List<Tiles>();

    void Start()
    {
        counterTask1 = Random.Range(5f, 10f);
        counterTask2 = Random.Range(5f, 10f);
        Debug.Log("start");
        timer = 0;
        Fill();
    }

    void Update()
    {
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;

        if(timer >= counterTask1)
        {
          var XYTrue = CheckXY();
          while (XYTrue == false) {
          XYTrue = CheckXY();
          timer = 0;
          PrintXY();
          counterTask1 = Random.Range(5f, 10f);
        }
      }
        if(timer2 >= counterTask2)
        {
          var XYTrue2 = CheckXY();
          while (XYTrue2 == false)
          {
          XYTrue2 = CheckXY();
          timer2 = 0;
          PrintXY();
          counterTask2 = Random.Range(5f, 10f);
          }
        }
    }

    public bool CheckXY() {
      int xNew = Random.Range(0, X.Count);
      int yNew = Random.Range(0, X[0].Y.Count);
      if (X[xNew].Y[yNew] == ResourceType.empty) {
        X[xNew].Y[yNew] = TypeOfResource();
        return true;
      } return false;
    }

    public ResourceType TypeOfResource() {
      int chosenResource = Random.Range(1, 4);
      if (chosenResource == 1) {
        return ResourceType.flat;
      } else if (chosenResource == 2) {
        return ResourceType.house;
      } else {
        return ResourceType.factory;
      }
  }

    public void PrintXY() {
      string Log = "";
      for (int k = 0; k < X.Count; k++) {
        var TilesP = X[k];
        for (int h = 0; h < TilesP.Y.Count; h++) {
          Log += X[k].Y[h];
        }
        Log += System.Environment.NewLine;
      }
      Debug.Log(Log);
    }

    public void Fill()
    {
      for (int i = 0; i < maxX; i++)
      {
        Tiles tile = new Tiles();

        for(int j = 0; j < maxY; j++)
        {
          tile.Y.Add(ResourceType.empty);
        }

        X.Add(tile);

      }
    }

}

public class Tiles
{
   public List<ResourceType> Y = new List<ResourceType>();
}

public enum ResourceType {
  empty,
  house,
  flat,
  factory
}
