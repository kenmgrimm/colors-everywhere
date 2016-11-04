using System.Collections.Generic;
using UnityEngine;

public class PaintbrushType : ItemType {
  private static List<PaintbrushType> paintbrushTypes;

  private int id;
  private string name;

  private GameObject prefab;

  private PaintbrushType (int id, string name) {
    this.id = id;
    this.name = name;

    this.prefab = Util.LoadPrefab(name);
  }

  public string Name() { return name; }

  public void Instantiate() {
    // return Util.Instantiate(sda)
  }

  public static PaintbrushType FindById(int id) {
    return paintbrushTypes[id];
  }

  public static List<PaintbrushType> PaintbrushTypes() {
    return paintbrushTypes;
  }

  public static List<ItemType> ItemTypes() {
    return PaintbrushTypes().ConvertAll<ItemType>(
			delegate(PaintbrushType paintbrushType) {
				return paintbrushType;
			}
		);
  }

  public static PaintbrushType Default() {
    return paintbrushTypes[0];
  }

static PaintbrushType() {
    var paintbrushTypesArr = new PaintbrushType[8] { 
      new PaintbrushType(0, "Cartoon Outline 1"),
      new PaintbrushType(0, "Four Stroke Solid"), 
      new PaintbrushType(0, "Glow Dot Add"),
      new PaintbrushType(0, "Glow Volumetric Alpha"),
      new PaintbrushType(0, "Ribbon Alpha"),
      new PaintbrushType(0, "Sparks Add .3"),
      new PaintbrushType(0, "Sparks Add Grow"),
      new PaintbrushType(0, "Thick Stroke Whispy")
    };

    paintbrushTypes = new List<PaintbrushType>(paintbrushTypesArr);
  }

}
