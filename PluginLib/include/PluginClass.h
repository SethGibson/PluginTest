#pragma once
#include <string>
#include "PluginCommon.h"

using namespace std;

class PLUGINEXPORT_API PluginClass {
public:
	PluginClass():mString("Placeholder") {}
	~PluginClass() {}

	void SetInt(int pInt) { mInt = pInt; }
	void SetFloat(float pFloat) {mFloat = pFloat;}
	void SetString(string pString) { mString = pString; }

	int GetInt() { return mInt; }
	float GetFloat() { return mFloat; }
	const char* GetString() { return mString.c_str(); }

private:
	int mInt;
	float mFloat;
	string mString;

};