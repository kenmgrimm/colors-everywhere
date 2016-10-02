public class ModelType {
  public int id;
  public string typeName;
  public string modelFile;
  public string iconFile;

  private static ModelType[] modelTypes;

  public ModelType (int id, string typeName, string modelFile, string iconFile) {
    this.id = id;
    this.typeName = typeName;
    this.modelFile = modelFile;
    this.iconFile = iconFile;
  }

  public static ModelType FindById(int id) {
    return modelTypes[id];
  }

  public static ModelType Default() {
    return modelTypes[0];
  }

static ModelType() {
    modelTypes = new ModelType[42] { 
      new ModelType(0, "cactus_01_01", "cactus_01_01", "None Yet"),
      new ModelType(1, "cactus_02_01", "cactus_02_01", "None Yet"),
      new ModelType(2, "cactus_03_01", "cactus_03_01", "None Yet"),
      new ModelType(3, "cactus_04_01", "cactus_04_01", "None Yet"),
      new ModelType(4, "plant_10_01", "plant_10_01", "None Yet"),
      new ModelType(5, "plant_08_01", "plant_08_01", "None Yet"),
      new ModelType(6, "plant_08_02", "plant_08_02", "None Yet"),
      new ModelType(7, "plant_08_03", "plant_08_03", "None Yet"),
      new ModelType(8, "plant_09_01", "plant_09_01", "None Yet"),
      new ModelType(9, "plant_10_01", "plant_10_01", "None Yet"),
      new ModelType(10, "plant_11_01", "plant_11_01", "None Yet"),
      new ModelType(11, "plant_12_01", "plant_12_01", "None Yet"),
      new ModelType(12, "plant_12_02", "plant_12_02", "None Yet"),
      new ModelType(13, "plant_13_01", "plant_13_01", "None Yet"),
      new ModelType(14, "plant_14_01", "plant_14_01", "None Yet"),
      new ModelType(15, "plant_15_01", "plant_15_01", "None Yet"),
      new ModelType(16, "rock_08_01", "rock_08_01", "None Yet"),
      new ModelType(17, "rock_08_02", "rock_08_02", "None Yet"),
      new ModelType(18, "rock_09_01", "rock_09_01", "None Yet"),
      new ModelType(19, "rock_09_02", "rock_09_02", "None Yet"),
      new ModelType(20, "rock_10_01", "rock_10_01", "None Yet"),
      new ModelType(21, "rock_10_02", "rock_10_02", "None Yet"),
      new ModelType(22, "tree_01_01", "tree_01_01", "None Yet"),
      new ModelType(23, "tree_01_02", "tree_01_02", "None Yet"),
      new ModelType(24, "tree_01_03", "tree_01_03", "None Yet"),
      new ModelType(25, "tree_01_04", "tree_01_04", "None Yet"),
      new ModelType(26, "tree_01_05", "tree_01_05", "None Yet"),
      new ModelType(27, "tree_02_01", "tree_02_01", "None Yet"),
      new ModelType(28, "tree_02_02", "tree_02_02", "None Yet"),
      new ModelType(29, "tree_02_03", "tree_02_03", "None Yet"),
      new ModelType(30, "tree_02_04", "tree_02_04", "None Yet"),
      new ModelType(31, "tree_02_05", "tree_02_05", "None Yet"),
      new ModelType(32, "tree_03_01", "tree_03_01", "None Yet"),
      new ModelType(33, "tree_03_02", "tree_03_02", "None Yet"),
      new ModelType(34, "tree_03_03", "tree_03_03", "None Yet"),
      new ModelType(35, "tree_03_04", "tree_03_04", "None Yet"),
      new ModelType(36, "tree_03_05", "tree_03_05", "None Yet"),
      new ModelType(37, "tree_04_01", "tree_04_01", "None Yet"),
      new ModelType(38, "tree_04_02", "tree_04_02", "None Yet"),
      new ModelType(39, "tree_04_03", "tree_04_03", "None Yet"),
      new ModelType(40, "tree_04_04", "tree_04_04", "None Yet"),
      new ModelType(41, "tree_04_05", "tree_04_05", "None Yet")  
    };
  }

}
