#include <string>
#include "PluginApi.h"
#include "PluginClass.h"

using namespace std;

const char*  PrintHello()
{
	return "Hello";
}

int PrintANumber()
{
	return 30;
}

int AddTwoIntegers(int a, int b)
{
	return a + b;
}

float AddTwoFloats(float a, float b)
{
	return a + b;
}

const char* Greeting(const char* name)
{
	string inName(name);
	auto greeting = "Greetings, " + inName;

	return greeting.c_str();
}

const simple_t GetStruct(int a, float b)
{
	simple_t ret;

	ret.m_int = a;
	ret.m_float = b;

	return ret;
}

#pragma region Class Wrapper
PluginClass* CreatePCInstance()
{
	return new PluginClass();
}

void DestroyPCInstance(PluginClass* pInstance)
{
	if (pInstance != nullptr) {
		delete pInstance;
		pInstance = nullptr;
	}
}

void PC_SetInt(PluginClass* pObj, int pInt)
{
	if (pObj != nullptr)
		pObj->SetInt(pInt);
}

void PC_SetFloat(PluginClass* pObj, float pFloat)
{
	if (pObj != nullptr)
		pObj->SetFloat(pFloat);
}

void PC_SetStr(PluginClass* pObj, const char* pStr)
{
	if (pObj != nullptr) {
		string val(pStr);
		pObj->SetString(val);
	}
}

int PC_GetInt(PluginClass* pObj)
{
	if (pObj != nullptr)
		return pObj->GetInt();

	return 0;
}

float PC_GetFloat(PluginClass* pObj)
{
	if (pObj != nullptr)
		return pObj->GetFloat();

	return 0.f;
}

const char* PC_GetStr(PluginClass* pObj)
{
	if (pObj != nullptr) {
		return pObj->GetString();
	}

	return nullptr;
}
#pragma endregion
