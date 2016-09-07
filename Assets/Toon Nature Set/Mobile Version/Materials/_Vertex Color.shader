
Shader " Vertex Color " {
Properties {
    _Color ("Main Color", Color) = (1,1,1,1)

    _MainTex ("Base (RGB)", 2D) = "white" {}
}

SubShader {
    Pass {
        Material {
      
        }
		Cull Off
        ColorMaterial AmbientAndDiffuse
        Lighting On
        SeparateSpecular On
        SetTexture [_MainTex] {
            Combine texture * primary, texture * primary
        }
        SetTexture [_MainTex] {
            constantColor [_Color]
            Combine previous * constant DOUBLE, previous * constant
        } 
		
    }
}

Fallback " VertexLit", 1
}