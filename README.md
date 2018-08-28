raknet_unity is a project to build raknet library for the platforms below

**android**<br>
  * [x] armeabi-v7a
  * [x] x86
  * [ ] x86_64
  * [ ] arm64-v8a
**[]iOS**<br>
**[x] widnow**<br>
**[x] mac**<br>
**[x] linux**<br>

Unity3dExample contain a simple client & server using raknet

TODO:
1. Window/DLL/DLL_vc8.vcproj添加swing输出的RakNet_wrap.h和RakNet_wrap.cxx文件
2. Window/LibStatic/LibStatic_vc9.vcproj添加swing输出的RakNet_wrap.h和RakNet_wrap.cxx文件
3. Window/LibStatic/LibStatic_vc8.vcproj添加swing输出的RakNet_wrap.h和RakNet_wrap.cxx文件
4. Swig\SwigOutput\SwigCSharpOutput\RakNetPINVOKE.cs部分接口缺少输出AOT.MonoPInvokeCallback特性的原因
