#pragma once

#include "PluginCommon.h"
#include "PluginStructs.h"
#include "PluginClass.h"

using namespace std;

#ifdef __cplusplus
extern "C" {
#endif

	PLUGINEXPORT_API const char* PrintHello();
	PLUGINEXPORT_API int PrintANumber();
	PLUGINEXPORT_API int AddTwoIntegers(int a, int b);
	PLUGINEXPORT_API float AddTwoFloats(float a, float b);
	PLUGINEXPORT_API const char* Greeting(const char* name);
	PLUGINEXPORT_API const simple_t GetStruct(int a, float b);

#pragma region Class Wrapper
	PLUGINEXPORT_API PluginClass* CreatePCInstance();
	PLUGINEXPORT_API void DestroyPCInstance(PluginClass* pInstance);
	PLUGINEXPORT_API void PC_SetInt(PluginClass* pObj, int pInt);
	PLUGINEXPORT_API void PC_SetFloat(PluginClass* pObj, float pFloat);
	PLUGINEXPORT_API void PC_SetStr(PluginClass* pObj, const char* pStr);

	PLUGINEXPORT_API int PC_GetInt(PluginClass* pObj);
	PLUGINEXPORT_API float PC_GetFloat(PluginClass* pObj);
	PLUGINEXPORT_API const char* PC_GetStr(PluginClass* pObj);

#pragma endregion

#ifdef __cplusplus
}
#endif