(function(){

if (
	typeof self !== 'undefined' && !self.Prism ||
	typeof global !== 'undefined' && !global.Prism
) {
	return;
}

if (Prism.languages.csharp) {
	Prism.languages.csharp['tag-id'] = /[\w-]+/;
	
	var Tags = {
		Unity: {
			'AnimationCurve': 1, 'Application': 1, 'Bounds': 1, 'Canvas': 1, 'Collider': 1, 'Color': 1, 'Color32': 1, 'Debug': 1, 'GameObject': 1, 'GUI': 1, 'GUIContent': 1, 'GUIStyle': 1, 'GUITexture': 1, 'Input': 1, 'KeyCode': 1, 'Material': 1, 'Mathf': 1, 'Mesh': 1, 'MeshFilter': 1, 'MeshRenderer': 1, 'MonoBehaviour': 1, 'PlayerPrefs': 1, 'Quaternion': 1, 'Rect': 1, 'RectTransform': 1, 'RectTransformUtility': 1, 'Resources': 1, 'Screen': 1, 'Shader': 1, 'Texture': 1, 'Texture2D': 1, 'TextureFormat': 1, 'TextureWrapMode': 1, 'Time': 1, 'Transform': 1, 'Vector2': 1, 'Vector3': 1
		},
		OnlineMaps: {
			'OnlineMaps': 1, 'OnlineMapsControlBase': 1, 'OnlineMapsControlBase3D': 1, 'OnlineMapsDirectionStep': 1, 'OnlineMapsDrawingLine': 1, 'OnlineMapsDrawingPoly': 1, 'OnlineMapsDrawingRect': 1, 'OnlineMapsFindAutocomplete': 1, 'OnlineMapsFindAutocompleteResult': 1, 'OnlineMapsFindDirection': 1, 'OnlineMapsFindLocation': 1, 'OnlineMapsFindPlaces': 1, 'OnlineMapsFindPlacesResult': 1, 'OnlineMapsGetElevation': 1, 'OnlineMapsGetElevationResult': 1, 'OnlineMapsGoogleAPIQuery': 1, 'OnlineMapsGUITextureControl': 1, 'OnlineMapsLocationService': 1, 'OnlineMapsMarker': 1, 'OnlineMapsMarker3D': 1, 'OnlineMapsMarkerBase': 1, 'OnlineMapsOSMAPIQuery': 1, 'OnlineMapsOSMNode': 1, 'OnlineMapsOSMRelation': 1, 'OnlineMapsOSMWay': 1, 'OnlineMapsPositionRange': 1, 'OnlineMapsRange': 1, 'OnlineMapsTile': 1, 'OnlineMapsTileSetControl': 1, 'OnlineMapsUtils': 1, 'OnlineMapsXML': 1
		}
	}
}

var language;

Prism.hooks.add('wrap', function(env) {
	if (env.type == 'tag-id' || env.type == 'class-name') 
	{
		if (Tags.Unity[env.content]) 
		{
			env.tag = 'a';
			var href = 'http://docs.unity3d.com/ScriptReference/';
			env.attributes.href = href + env.content + ".html";
			env.attributes.target = '_blank';
			env.attributes.title = 'Open Unity Scripting Reference';
		}
		else if (Tags.OnlineMaps[env.content]) 
		{
			env.tag = 'a';
			var href = 'http://infinity-code.com/doxygen/online-maps/class';
			env.attributes.href = href + env.content + ".html";
			env.attributes.target = '_blank';
			env.attributes.title = 'Open Online Maps API Reference';
		}
		else if (/[A-Z]/.test(env.content[0])) console.log(env.content);
	}
});

})();