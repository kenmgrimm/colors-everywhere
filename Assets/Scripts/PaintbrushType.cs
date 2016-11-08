using System.Collections.Generic;
using UnityEngine;

public class PaintbrushType : ItemType {
  private static List<PaintbrushType> paintbrushTypes;

  private int id;
  private string name;

  public GameObject lineRendererPrefab;

  private PaintbrushType (int id, string name, string rendererPath) {
    this.id = id;
    this.name = name;

    this.lineRendererPrefab = Util.LoadPrefab(rendererPath);
  }

  public int BrushType() {
    return id;
  }

  public string Name() { return name; }

  public LineRenderer CreateRendererInstance(Transform parent = null) {
    return ((GameObject)GameObject.Instantiate(lineRendererPrefab, parent))
      .GetComponent<LineRenderer>();
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
    return paintbrushTypes[2];
  }

static PaintbrushType() {
    var paintbrushTypesArr = new PaintbrushType[5] {
      new PaintbrushType(0, "Full Metal", "Brushes/Full Metal"),
      new PaintbrushType(1, "Fire Smoke", "Brushes/Fire Smoke"),
      new PaintbrushType(2, "Full Color", "Brushes/Full Color"),
      new PaintbrushType(3, "Colora Palette", "Brushes/Color Palette"),
      new PaintbrushType(4, "Red Blurry Dot", "Brushes/Red Blurry Dot")
      // new PaintbrushType(2, "Cartoon Outline 1"),
      // new PaintbrushType(3, "Four Stroke Solid"), 
      // new PaintbrushType(4, "Glow Dot Add"),
      // new PaintbrushType(5, "Glow Volumetric Alpha"),
      // new PaintbrushType(6, "Ribbon Alpha"),
      // new PaintbrushType(7, "Sparks Add .3"),
      // new PaintbrushType(8, "Sparks Add Grow"),
      // new PaintbrushType(9, "Thick Stroke Whispy")
    };

    paintbrushTypes = new List<PaintbrushType>(paintbrushTypesArr);
  }

}
