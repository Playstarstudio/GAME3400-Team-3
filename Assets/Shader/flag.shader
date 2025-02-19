Shader "Custom/flag"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _Color("color",Color) = (1,1,1,1)
        _Front("前后振幅",float) = 1  //幅度
        _Up("上下振幅",float) = 1  //幅度
        _Right("左右振幅",float) = 1  //幅度
        _H("旗尾高度",float) = 1  //幅度
        _W("旗尾宽度",float) = 1  //幅度
        _L("旗长",float) = 1  //幅度
        _S("风速",float) = 1//风速
    }
        SubShader
        {


            Pass
            {
                Cull Off
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag

                #include "UnityCG.cginc"
                #include "Lighting.cginc "

                struct appdata
                {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };

                struct v2f
                {
                    float2 uv : TEXCOORD0;
                    float4 vertex : SV_POSITION;
                };

                float _Front;
                float _H;
                float _W;
                float _L;
                float _Up;
                float _S;
                float _Right;

                fixed4 _Color;
                v2f vert(appdata v)
                {
                    v2f o;

                    float vertexAll = (v.vertex.x + v.vertex.y + v.vertex.z)* 0.333;
                    float sinInfo= sin(_Time.y*_S + vertexAll)* v.uv.x;
                    v.vertex.y += _Front * sinInfo;
                    v.vertex.x += _Right * sinInfo;
                    v.vertex.z += _Up * sinInfo;
                    v.vertex.z += _H * v.uv.x+ _W * v.uv.x* v.uv.y;
                    v.vertex.x += _L * v.uv.x;


                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = v.uv;
                    return o;
                }

                sampler2D _MainTex;

                fixed4 frag(v2f i) : SV_Target
                {

                    fixed4 col = tex2D(_MainTex, i.uv)*_Color;

                return col;
            }
            ENDCG
        }
        }
}
