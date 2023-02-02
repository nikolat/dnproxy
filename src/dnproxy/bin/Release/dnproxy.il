
//  Microsoft (R) .NET Framework IL Disassembler.  Version 2.0.50727.42
//  Copyright (c) Microsoft Corporation.  All rights reserved.



// Metadata version: v2.0.50727
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 2:0:0:0
}
.assembly extern System.Xml
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 2:0:0:0
}
.assembly extern System.Windows.Forms
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 2:0:0:0
}
.assembly dnproxy
{
  .custom instance void [mscorlib]System.Reflection.AssemblyProductAttribute::.ctor(string) = ( 01 00 07 64 6E 70 72 6F 78 79 00 00 )             // ...dnproxy..
  .custom instance void [mscorlib]System.Reflection.AssemblyFileVersionAttribute::.ctor(string) = ( 01 00 07 32 2E 30 2E 30 2E 30 00 00 )             // ...2.0.0.0..
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 37 30 30 62 35 37 33 38 2D 34 32 37 66   // ..$700b5738-427f
                                                                                                  2D 34 64 63 31 2D 62 34 31 36 2D 38 35 35 39 65   // -4dc1-b416-8559e
                                                                                                  66 65 63 33 31 33 38 00 00 )                      // fec3138..
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComVisibleAttribute::.ctor(bool) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyTrademarkAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyCopyrightAttribute::.ctor(string) = ( 01 00 1A 43 6F 70 79 72 69 67 68 74 20 28 43 29   // ...Copyright (C)
                                                                                                  20 55 6E 6B 6E 6F 77 6E 20 32 30 30 38 00 00 )    //  Unknown 2008..
  .custom instance void [mscorlib]System.Reflection.AssemblyDescriptionAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyCompanyAttribute::.ctor(string) = ( 01 00 07 55 6E 6B 6E 6F 77 6E 00 00 )             // ...Unknown..
  .custom instance void [mscorlib]System.Reflection.AssemblyConfigurationAttribute::.ctor(string) = ( 01 00 00 00 00 ) 

  // --- ���̃J�X�^�������������I�ɒǉ�����܂����B�R�����g�������Ȃ��ł������� -------
  //  .custom instance void [mscorlib]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 02 00 00 00 00 00 ) 

  .custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                             63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.
  .custom instance void [mscorlib]System.Reflection.AssemblyTitleAttribute::.ctor(string) = ( 01 00 16 44 2E 4E 2E 50 72 6F 78 79 20 28 2E 4E   // ...D.N.Proxy (.N
                                                                                              45 54 20 50 72 6F 78 79 29 00 00 )                // ET Proxy)..
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .hash algorithm 0x00008004
  .ver 2:0:0:0
}
.module dnproxy.dll
// MVID: {41E210BE-90CA-4829-B501-1A3A76BC5B09}
.imagebase 0x00400000
.file alignment 0x00001000
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000002    // 32BITREQUIRED
// Image base: 0x03DE0000
.data VT_01 = int32[11]
.vtfixup [11] int32 fromunmanaged at VT_01



// =============== CLASS MEMBERS DECLARATION ===================

.class private abstract auto ansi sealed beforefieldinit D.N.Proxy
       extends [mscorlib]System.Object
{
  .class sequential ansi sealed nested private beforefieldinit RemoteMethods
         extends [mscorlib]System.ValueType
  {
    .field public class [mscorlib]System.Reflection.MethodInfo GetVersion
    .field public class [mscorlib]System.Reflection.MethodInfo Load
    .field public class [mscorlib]System.Reflection.MethodInfo Unload
    .field public class [mscorlib]System.Reflection.MethodInfo Request
    .field public class [mscorlib]System.Reflection.MethodInfo Notify
    .field public class [mscorlib]System.Reflection.MethodInfo Configure
    .field public class [mscorlib]System.Reflection.MethodInfo Execute
    .field public class [mscorlib]System.Reflection.MethodInfo GetUrl
    .field public class [mscorlib]System.Reflection.MethodInfo GetSchedule
    .field public class [mscorlib]System.Reflection.MethodInfo GetUrlPost
  } // end of class RemoteMethods

  .class auto ansi sealed nested private beforefieldinit '<>c__DisplayClass2'
         extends [mscorlib]System.Object
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    .field public string selfdir
    .method public hidebysig specialname rtspecialname 
            instance void  .ctor() cil managed
    {
      // �R�[�h �T�C�Y       7 (0x7)
      .maxstack  8
      IL_0000:  ldarg.0
      IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
      IL_0006:  ret
    } // end of method '<>c__DisplayClass2'::.ctor

    .method public hidebysig instance class [mscorlib]System.Reflection.Assembly 
            '<initialize>b__0'(object sender,
                               class [mscorlib]System.ResolveEventArgs args) cil managed
    {
      // �R�[�h �T�C�Y       49 (0x31)
      .maxstack  5
      .locals init ([0] string dll)
      .language '{3F5162F8-07C6-11D3-9053-00C04FA302A1}', '{994B45C4-E6E9-11D2-903F-00C04FA302A1}', '{5A869D0B-6611-11D3-BD2A-0000F80849BD}'
      .line 188,188 : 25,104 'H:\\workspace\\dnproxy_sepif\\dnproxy\\Proxy.cs'
      IL_0000:  ldarg.0
      IL_0001:  ldfld      string D.N.Proxy/'<>c__DisplayClass2'::selfdir
      IL_0006:  ldarg.2
      IL_0007:  callvirt   instance string [mscorlib]System.ResolveEventArgs::get_Name()
      IL_000c:  ldc.i4.0
      IL_000d:  ldarg.2
      IL_000e:  callvirt   instance string [mscorlib]System.ResolveEventArgs::get_Name()
      IL_0013:  ldc.i4.s   44
      IL_0015:  callvirt   instance int32 [mscorlib]System.String::IndexOf(char)
      IL_001a:  callvirt   instance string [mscorlib]System.String::Substring(int32,
                                                                              int32)
      IL_001f:  ldstr      ".dll"
      IL_0024:  call       string [mscorlib]System.String::Concat(string,
                                                                  string,
                                                                  string)
      IL_0029:  stloc.0
      .line 189,189 : 25,55 ''
      IL_002a:  ldloc.0
      IL_002b:  call       class [mscorlib]System.Reflection.Assembly [mscorlib]System.Reflection.Assembly::LoadFrom(string)
      IL_0030:  ret
    } // end of method '<>c__DisplayClass2'::'<initialize>b__0'

  } // end of class '<>c__DisplayClass2'

  .field private static literal string REMOTE_INTERFACE = "Ukagaka.NET.Interfaces"
  .field private static literal string GENERATOR_NAME = "dngen.dll"
  .field private static literal string GENERATOR_MAINCLASS = "D.N.Generator"
  .field private static literal string UTILITY_NAME = "dnutil.dll"
  .field private static literal string UTILITY_MAINCLASS = "D.N.Manager"
  .field private static class [mscorlib]System.AppDomain domain
  .field private static object utility
  .field private static object 'instance'
  .field private static string protocol
  .field private static valuetype D.N.Proxy/RemoteMethods remote
  .method private hidebysig static class [System.Xml]System.Xml.XmlElement 
          configSettingsElement(class [System.Xml]System.Xml.XmlDocument doc) cil managed
  {
    // �R�[�h �T�C�Y       32 (0x20)
    .maxstack  8
    .line 105,105 : 13,91 ''
    IL_0000:  ldarg.0
    IL_0001:  ldstr      "configuration"
    IL_0006:  callvirt   instance class [System.Xml]System.Xml.XmlElement [System.Xml]System.Xml.XmlNode::get_Item(string)
    IL_000b:  ldstr      "applicationSettings"
    IL_0010:  callvirt   instance class [System.Xml]System.Xml.XmlElement [System.Xml]System.Xml.XmlNode::get_Item(string)
    IL_0015:  ldstr      "D.N.Properties.Settings"
    IL_001a:  callvirt   instance class [System.Xml]System.Xml.XmlElement [System.Xml]System.Xml.XmlNode::get_Item(string)
    IL_001f:  ret
  } // end of method Proxy::configSettingsElement

  .method private hidebysig static string 
          getAssemblyData(class [System.Xml]System.Xml.XmlElement element,
                          string key) cil managed
  {
    // �R�[�h �T�C�Y       276 (0x114)
    .maxstack  2
    .locals init ([0] class [System.Xml]System.Xml.XmlNode node,
             [1] class [System.Xml]System.Xml.XmlAttribute attr,
             [2] class [System.Xml]System.Xml.XmlNode target,
             [3] string CS$1$0000,
             [4] class [mscorlib]System.Collections.IEnumerator CS$5$0001,
             [5] class [mscorlib]System.Collections.IEnumerator CS$5$0002,
             [6] class [mscorlib]System.Collections.IEnumerator CS$5$0003,
             [7] class [mscorlib]System.IDisposable CS$0$0004,
             [8] class [mscorlib]System.IDisposable CS$0$0005,
             [9] class [mscorlib]System.IDisposable CS$0$0006)
    .line 116,116 : 38,45 ''
    IL_0000:  ldarg.0
    IL_0001:  callvirt   instance class [mscorlib]System.Collections.IEnumerator [System.Xml]System.Xml.XmlNode::GetEnumerator()
    IL_0006:  stloc.s    CS$5$0001
    .try
    {
      IL_0008:  br         IL_00ed

      .line 116,116 : 22,34 ''
      IL_000d:  ldloc.s    CS$5$0001
      IL_000f:  callvirt   instance object [mscorlib]System.Collections.IEnumerator::get_Current()
      IL_0014:  castclass  [System.Xml]System.Xml.XmlNode
      IL_0019:  stloc.0
      .line 117,117 : 17,44 ''
      IL_001a:  ldloc.0
      IL_001b:  callvirt   instance string [System.Xml]System.Xml.XmlNode::get_Name()
      IL_0020:  ldstr      "setting"
      IL_0025:  call       bool [mscorlib]System.String::op_Equality(string,
                                                                     string)
      IL_002a:  brfalse    IL_00ed

      .line 118,118 : 51,66 ''
      IL_002f:  ldloc.0
      IL_0030:  callvirt   instance class [System.Xml]System.Xml.XmlAttributeCollection [System.Xml]System.Xml.XmlNode::get_Attributes()
      IL_0035:  callvirt   instance class [mscorlib]System.Collections.IEnumerator [System.Xml]System.Xml.XmlNamedNodeMap::GetEnumerator()
      IL_003a:  stloc.s    CS$5$0002
      .try
      {
        IL_003c:  br         IL_00ca

        .line 118,118 : 30,47 ''
        IL_0041:  ldloc.s    CS$5$0002
        IL_0043:  callvirt   instance object [mscorlib]System.Collections.IEnumerator::get_Current()
        IL_0048:  castclass  [System.Xml]System.Xml.XmlAttribute
        IL_004d:  stloc.1
        .line 119,119 : 25,70 ''
        IL_004e:  ldloc.1
        IL_004f:  callvirt   instance string [System.Xml]System.Xml.XmlNode::get_Name()
        IL_0054:  ldstr      "name"
        IL_0059:  call       bool [mscorlib]System.String::op_Equality(string,
                                                                       string)
        IL_005e:  brfalse.s  IL_00ca

        IL_0060:  ldloc.1
        IL_0061:  callvirt   instance string [System.Xml]System.Xml.XmlNode::get_Value()
        IL_0066:  ldarg.1
        IL_0067:  call       bool [mscorlib]System.String::op_Equality(string,
                                                                       string)
        IL_006c:  brfalse.s  IL_00ca

        .line 120,120 : 56,71 ''
        IL_006e:  ldloc.0
        IL_006f:  callvirt   instance class [System.Xml]System.Xml.XmlNodeList [System.Xml]System.Xml.XmlNode::get_ChildNodes()
        IL_0074:  callvirt   instance class [mscorlib]System.Collections.IEnumerator [System.Xml]System.Xml.XmlNodeList::GetEnumerator()
        IL_0079:  stloc.s    CS$5$0003
        .try
        {
          IL_007b:  br.s       IL_00aa

          .line 120,120 : 38,52 ''
          IL_007d:  ldloc.s    CS$5$0003
          IL_007f:  callvirt   instance object [mscorlib]System.Collections.IEnumerator::get_Current()
          IL_0084:  castclass  [System.Xml]System.Xml.XmlNode
          IL_0089:  stloc.2
          .line 121,121 : 33,60 ''
          IL_008a:  ldloc.2
          IL_008b:  callvirt   instance string [System.Xml]System.Xml.XmlNode::get_Name()
          IL_0090:  ldstr      "value"
          IL_0095:  call       bool [mscorlib]System.String::op_Equality(string,
                                                                         string)
          IL_009a:  brfalse.s  IL_00aa

          .line 122,122 : 37,68 ''
          IL_009c:  ldloc.2
          IL_009d:  callvirt   instance class [System.Xml]System.Xml.XmlNode [System.Xml]System.Xml.XmlNode::get_FirstChild()
          IL_00a2:  callvirt   instance string [System.Xml]System.Xml.XmlNode::get_Value()
          IL_00a7:  stloc.3
          IL_00a8:  leave.s    IL_0112

          .line 120,120 : 53,55 ''
          IL_00aa:  ldloc.s    CS$5$0003
          IL_00ac:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
          IL_00b1:  brtrue.s   IL_007d

          IL_00b3:  leave.s    IL_00ca

        }  // end .try
        finally
        {
          IL_00b5:  ldloc.s    CS$5$0003
          IL_00b7:  isinst     [mscorlib]System.IDisposable
          IL_00bc:  stloc.s    CS$0$0004
          IL_00be:  ldloc.s    CS$0$0004
          IL_00c0:  brfalse.s  IL_00c9

          IL_00c2:  ldloc.s    CS$0$0004
          IL_00c4:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
          IL_00c9:  endfinally
          .line 118,118 : 48,50 ''
        }  // end handler
        IL_00ca:  ldloc.s    CS$5$0002
        IL_00cc:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
        IL_00d1:  brtrue     IL_0041

        IL_00d6:  leave.s    IL_00ed

      }  // end .try
      finally
      {
        IL_00d8:  ldloc.s    CS$5$0002
        IL_00da:  isinst     [mscorlib]System.IDisposable
        IL_00df:  stloc.s    CS$0$0005
        IL_00e1:  ldloc.s    CS$0$0005
        IL_00e3:  brfalse.s  IL_00ec

        IL_00e5:  ldloc.s    CS$0$0005
        IL_00e7:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
        IL_00ec:  endfinally
        .line 116,116 : 35,37 ''
      }  // end handler
      IL_00ed:  ldloc.s    CS$5$0001
      IL_00ef:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_00f4:  brtrue     IL_000d

      IL_00f9:  leave.s    IL_0110

    }  // end .try
    finally
    {
      IL_00fb:  ldloc.s    CS$5$0001
      IL_00fd:  isinst     [mscorlib]System.IDisposable
      IL_0102:  stloc.s    CS$0$0006
      IL_0104:  ldloc.s    CS$0$0006
      IL_0106:  brfalse.s  IL_010f

      IL_0108:  ldloc.s    CS$0$0006
      IL_010a:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_010f:  endfinally
      .line 129,129 : 13,25 ''
    }  // end handler
    IL_0110:  ldnull
    IL_0111:  ret

    .line 130,130 : 9,10 ''
    IL_0112:  ldloc.3
    IL_0113:  ret
  } // end of method Proxy::getAssemblyData

  .method private hidebysig static bool  initialize() cil managed
  {
    // �R�[�h �T�C�Y       1607 (0x647)
    .maxstack  6
    .locals init ([0] string selfpath,
             [1] string appconf,
             [2] string privateBinPath,
             [3] string assemblyName,
             [4] string mainClass,
             [5] class [System.Xml]System.Xml.XmlDocument doc,
             [6] class [System.Xml]System.Xml.XmlElement element,
             [7] class [mscorlib]System.AppDomainSetup setup,
             [8] class [mscorlib]System.Reflection.Assembly 'assembly',
             [9] class [mscorlib]System.Exception e,
             [10] string genpath,
             [11] string genconf,
             [12] object generator,
             [13] native int h,
             [14] int32 len,
             [15] class [mscorlib]System.Exception V_15,
             [16] string utilpath,
             [17] object V_17,
             [18] string config,
             [19] native int V_19,
             [20] int32 V_20,
             [21] class [mscorlib]System.Exception V_21,
             [22] class [mscorlib]System.Exception V_22,
             [23] class [mscorlib]System.ResolveEventHandler '<>9__CachedAnonymousMethodDelegate1',
             [24] class D.N.Proxy/'<>c__DisplayClass2' '<>8__locals3',
             [25] bool CS$1$0000,
             [26] class [mscorlib]System.Type[] CS$0$0001,
             [27] class [mscorlib]System.Type[] CS$0$0002,
             [28] class [mscorlib]System.Type[] CS$0$0003,
             [29] class [mscorlib]System.Type[] CS$0$0004,
             [30] class [mscorlib]System.Type[] CS$0$0005,
             [31] class [mscorlib]System.Type[] CS$0$0006,
             [32] class [mscorlib]System.Type[] CS$0$0007,
             [33] class [mscorlib]System.Type[] CS$0$0008,
             [34] class [mscorlib]System.Type[] CS$0$0009,
             [35] object[] CS$0$0010,
             [36] object[] CS$0$0011,
             [37] object[] CS$0$0012,
             [38] object[] CS$0$0013)
    IL_0000:  ldnull
    IL_0001:  stloc.s    '<>9__CachedAnonymousMethodDelegate1'
    IL_0003:  newobj     instance void D.N.Proxy/'<>c__DisplayClass2'::.ctor()
    IL_0008:  stloc.s    '<>8__locals3'
    .line 145,145 : 13,72 ''
    IL_000a:  call       class [mscorlib]System.Reflection.Assembly [mscorlib]System.Reflection.Assembly::GetExecutingAssembly()
    IL_000f:  callvirt   instance string [mscorlib]System.Reflection.Assembly::get_Location()
    IL_0014:  stloc.0
    .line 152,152 : 13,38 ''
    IL_0015:  ldsfld     class [mscorlib]System.AppDomain D.N.Proxy::domain
    IL_001a:  brfalse.s  IL_001e

    .line 153,153 : 17,29 ''
    IL_001c:  ldc.i4.1
    IL_001d:  ret

    .line 155,155 : 13,67 ''
    IL_001e:  call       class [mscorlib]System.AppDomain [mscorlib]System.AppDomain::get_CurrentDomain()
    IL_0023:  callvirt   instance string [mscorlib]System.AppDomain::get_BaseDirectory()
    IL_0028:  pop
    .line 156,156 : 13,92 ''
    IL_0029:  ldloc.s    '<>8__locals3'
    IL_002b:  ldloc.0
    IL_002c:  call       string [mscorlib]System.IO.Path::GetDirectoryName(string)
    IL_0031:  ldsfld     char [mscorlib]System.IO.Path::DirectorySeparatorChar
    IL_0036:  box        [mscorlib]System.Char
    IL_003b:  call       string [mscorlib]System.String::Concat(object,
                                                                object)
    IL_0040:  stfld      string D.N.Proxy/'<>c__DisplayClass2'::selfdir
    .line 159,159 : 13,51 ''
    IL_0045:  ldloc.0
    IL_0046:  ldstr      ".config"
    IL_004b:  call       string [mscorlib]System.String::Concat(string,
                                                                string)
    IL_0050:  stloc.1
    .line 160,160 : 13,42 ''
    IL_0051:  ldnull
    IL_0052:  stloc.2
    .line 161,161 : 13,42 ''
    IL_0053:  ldnull
    IL_0054:  stloc.3
    .line 162,162 : 13,42 ''
    IL_0055:  ldnull
    IL_0056:  stloc.s    mainClass
    .line 163,163 : 13,38 ''
    IL_0058:  ldloc.1
    IL_0059:  call       bool [mscorlib]System.IO.File::Exists(string)
    IL_005e:  brfalse.s  IL_00b1

    .line 165,165 : 17,53 ''
    IL_0060:  newobj     instance void [System.Xml]System.Xml.XmlDocument::.ctor()
    IL_0065:  stloc.s    doc
    .line 166,166 : 17,35 ''
    IL_0067:  ldloc.s    doc
    IL_0069:  ldloc.1
    IL_006a:  callvirt   instance void [System.Xml]System.Xml.XmlDocument::Load(string)
    .line 168,168 : 17,71 ''
    IL_006f:  ldloc.s    doc
    IL_0071:  call       class [System.Xml]System.Xml.XmlElement D.N.Proxy::configSettingsElement(class [System.Xml]System.Xml.XmlDocument)
    IL_0076:  stloc.s    element
    .line 169,169 : 17,77 ''
    IL_0078:  ldloc.s    element
    IL_007a:  ldstr      "Protocol"
    IL_007f:  call       string D.N.Proxy::getAssemblyData(class [System.Xml]System.Xml.XmlElement,
                                                           string)
    IL_0084:  stsfld     string D.N.Proxy::protocol
    .line 170,170 : 17,83 ''
    IL_0089:  ldloc.s    element
    IL_008b:  ldstr      "PrivateBinPath"
    IL_0090:  call       string D.N.Proxy::getAssemblyData(class [System.Xml]System.Xml.XmlElement,
                                                           string)
    IL_0095:  stloc.2
    .line 171,171 : 17,81 ''
    IL_0096:  ldloc.s    element
    IL_0098:  ldstr      "AssemblyName"
    IL_009d:  call       string D.N.Proxy::getAssemblyData(class [System.Xml]System.Xml.XmlElement,
                                                           string)
    IL_00a2:  stloc.3
    .line 172,172 : 17,78 ''
    IL_00a3:  ldloc.s    element
    IL_00a5:  ldstr      "MainClass"
    IL_00aa:  call       string D.N.Proxy::getAssemblyData(class [System.Xml]System.Xml.XmlElement,
                                                           string)
    IL_00af:  stloc.s    mainClass
    .line 176,176 : 13,57 ''
    IL_00b1:  newobj     instance void [mscorlib]System.AppDomainSetup::.ctor()
    IL_00b6:  stloc.s    setup
    .line 177,177 : 13,47 ''
    IL_00b8:  ldloc.s    setup
    IL_00ba:  ldloc.1
    IL_00bb:  callvirt   instance void [mscorlib]System.AppDomainSetup::set_ConfigurationFile(string)
    .line 178,178 : 13,47 ''
    IL_00c0:  ldloc.s    setup
    IL_00c2:  ldloc.s    '<>8__locals3'
    IL_00c4:  ldfld      string D.N.Proxy/'<>c__DisplayClass2'::selfdir
    IL_00c9:  callvirt   instance void [mscorlib]System.AppDomainSetup::set_ApplicationBase(string)
    .line 179,179 : 13,54 ''
    IL_00ce:  ldloc.s    setup
    IL_00d0:  ldloc.2
    IL_00d1:  callvirt   instance void [mscorlib]System.AppDomainSetup::set_PrivateBinPath(string)
    .line 182,182 : 13,74 ''
    IL_00d6:  ldloc.0
    IL_00d7:  ldnull
    IL_00d8:  ldloc.s    setup
    IL_00da:  call       class [mscorlib]System.AppDomain [mscorlib]System.AppDomain::CreateDomain(string,
                                                                                                   class [mscorlib]System.Security.Policy.Evidence,
                                                                                                   class [mscorlib]System.AppDomainSetup)
    IL_00df:  stsfld     class [mscorlib]System.AppDomain D.N.Proxy::domain
    .line 186,190 : 17,24 ''
    .try
    {
      IL_00e4:  call       class [mscorlib]System.AppDomain [mscorlib]System.AppDomain::get_CurrentDomain()
      IL_00e9:  ldloc.s    '<>9__CachedAnonymousMethodDelegate1'
      IL_00eb:  brtrue.s   IL_00fc

      IL_00ed:  ldloc.s    '<>8__locals3'
      IL_00ef:  ldftn      instance class [mscorlib]System.Reflection.Assembly D.N.Proxy/'<>c__DisplayClass2'::'<initialize>b__0'(object,
                                                                                                                                  class [mscorlib]System.ResolveEventArgs)
      IL_00f5:  newobj     instance void [mscorlib]System.ResolveEventHandler::.ctor(object,
                                                                                     native int)
      IL_00fa:  stloc.s    '<>9__CachedAnonymousMethodDelegate1'
      IL_00fc:  ldloc.s    '<>9__CachedAnonymousMethodDelegate1'
      IL_00fe:  callvirt   instance void [mscorlib]System.AppDomain::add_AssemblyResolve(class [mscorlib]System.ResolveEventHandler)
      .line 192,192 : 17,98 ''
      IL_0103:  ldloc.s    '<>8__locals3'
      IL_0105:  ldfld      string D.N.Proxy/'<>c__DisplayClass2'::selfdir
      IL_010a:  ldstr      "Ukagaka.NET.Interfaces.dll"
      IL_010f:  call       string [mscorlib]System.String::Concat(string,
                                                                  string)
      IL_0114:  call       class [mscorlib]System.Reflection.Assembly [mscorlib]System.Reflection.Assembly::LoadFrom(string)
      IL_0119:  stloc.s    'assembly'
      .line 193,194 : 17,79 ''
      IL_011b:  ldsflda    valuetype D.N.Proxy/RemoteMethods D.N.Proxy::remote
      IL_0120:  ldloc.s    'assembly'
      IL_0122:  ldstr      "Ukagaka.NET.Interfaces.IGetVersion"
      IL_0127:  callvirt   instance class [mscorlib]System.Type [mscorlib]System.Reflection.Assembly::GetType(string)
      IL_012c:  ldstr      "getversion"
      IL_0131:  ldc.i4.1
      IL_0132:  newarr     [mscorlib]System.Type
      IL_0137:  stloc.s    CS$0$0001
      IL_0139:  ldloc.s    CS$0$0001
      IL_013b:  ldc.i4.0
      IL_013c:  ldtoken    [mscorlib]System.Int32
      IL_0141:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
      IL_0146:  callvirt   instance class [mscorlib]System.Type [mscorlib]System.Type::MakeByRefType()
      IL_014b:  stelem.ref
      IL_014c:  ldloc.s    CS$0$0001
      IL_014e:  callvirt   instance class [mscorlib]System.Reflection.MethodInfo [mscorlib]System.Type::GetMethod(string,
                                                                                                                  class [mscorlib]System.Type[])
      IL_0153:  stfld      class [mscorlib]System.Reflection.MethodInfo D.N.Proxy/RemoteMethods::GetVersion
      .line 195,196 : 17,73 ''
      IL_0158:  ldsflda    valuetype D.N.Proxy/RemoteMethods D.N.Proxy::remote
      IL_015d:  ldloc.s    'assembly'
      IL_015f:  ldstr      "Ukagaka.NET.Interfaces.ILoad"
      IL_0164:  callvirt   instance class [mscorlib]System.Type [mscorlib]System.Reflection.Assembly::GetType(string)
      IL_0169:  ldstr      "load"
      IL_016e:  ldc.i4.2
      IL_016f:  newarr     [mscorlib]System.Type
      IL_0174:  stloc.s    CS$0$0002
      IL_0176:  ldloc.s    CS$0$0002
      IL_0178:  ldc.i4.0
      IL_0179:  ldtoken    [mscorlib]System.IntPtr
      IL_017e:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
      IL_0183:  stelem.ref
      IL_0184:  ldloc.s    CS$0$0002
      IL_0186:  ldc.i4.1
      IL_0187:  ldtoken    [mscorlib]System.Int32
      IL_018c:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
      IL_0191:  stelem.ref
      IL_0192:  ldloc.s    CS$0$0002
      IL_0194:  callvirt   instance class [mscorlib]System.Reflection.MethodInfo [mscorlib]System.Type::GetMethod(string,
                                                                                                                  class [mscorlib]System.Type[])
      IL_0199:  stfld      class [mscorlib]System.Reflection.MethodInfo D.N.Proxy/RemoteMethods::Load
      .line 197,198 : 17,31 ''
      IL_019e:  ldsflda    valuetype D.N.Proxy/RemoteMethods D.N.Proxy::remote
      IL_01a3:  ldloc.s    'assembly'
      IL_01a5:  ldstr      "Ukagaka.NET.Interfaces.IUnload"
      IL_01aa:  callvirt   instance class [mscorlib]System.Type [mscorlib]System.Reflection.Assembly::GetType(string)
      IL_01af:  ldstr      "unload"
      IL_01b4:  callvirt   instance class [mscorlib]System.Reflection.MethodInfo [mscorlib]System.Type::GetMethod(string)
      IL_01b9:  stfld      class [mscorlib]System.Reflection.MethodInfo D.N.Proxy/RemoteMethods::Unload
      .line 199,200 : 17,92 ''
      IL_01be:  ldsflda    valuetype D.N.Proxy/RemoteMethods D.N.Proxy::remote
      IL_01c3:  ldloc.s    'assembly'
      IL_01c5:  ldstr      "Ukagaka.NET.Interfaces.IRequest"
      IL_01ca:  callvirt   instance class [mscorlib]System.Type [mscorlib]System.Reflection.Assembly::GetType(string)
      IL_01cf:  ldstr      "request"
      IL_01d4:  ldc.i4.2
      IL_01d5:  newarr     [mscorlib]System.Type
      IL_01da:  stloc.s    CS$0$0003
      IL_01dc:  ldloc.s    CS$0$0003
      IL_01de:  ldc.i4.0
      IL_01df:  ldtoken    [mscorlib]System.IntPtr
      IL_01e4:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
      IL_01e9:  stelem.ref
      IL_01ea:  ldloc.s    CS$0$0003
      IL_01ec:  ldc.i4.1
      IL_01ed:  ldtoken    [mscorlib]System.Int32
      IL_01f2:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
      IL_01f7:  callvirt   instance class [mscorlib]System.Type [mscorlib]System.Type::MakeByRefType()
      IL_01fc:  stelem.ref
      IL_01fd:  ldloc.s    CS$0$0003
      IL_01ff:  callvirt   instance class [mscorlib]System.Reflection.MethodInfo [mscorlib]System.Type::GetMethod(string,
                                                                                                                  class [mscorlib]System.Type[])
      IL_0204:  stfld      class [mscorlib]System.Reflection.MethodInfo D.N.Proxy/RemoteMethods::Request
      .line 201,202 : 17,91 ''
      IL_0209:  ldsflda    valuetype D.N.Proxy/RemoteMethods D.N.Proxy::remote
      IL_020e:  ldloc.s    'assembly'
      IL_0210:  ldstr      "Ukagaka.NET.Interfaces.INotify"
      IL_0215:  callvirt   instance class [mscorlib]System.Type [mscorlib]System.Reflection.Assembly::GetType(string)
      IL_021a:  ldstr      "notify"
      IL_021f:  ldc.i4.2
      IL_0220:  newarr     [mscorlib]System.Type
      IL_0225:  stloc.s    CS$0$0004
      IL_0227:  ldloc.s    CS$0$0004
      IL_0229:  ldc.i4.0
      IL_022a:  ldtoken    [mscorlib]System.IntPtr
      IL_022f:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
      IL_0234:  stelem.ref
      IL_0235:  ldloc.s    CS$0$0004
      IL_0237:  ldc.i4.1
      IL_0238:  ldtoken    [mscorlib]System.Int32
      IL_023d:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
      IL_0242:  callvirt   instance class [mscorlib]System.Type [mscorlib]System.Type::MakeByRefType()
      IL_0247:  stelem.ref
      IL_0248:  ldloc.s    CS$0$0004
      IL_024a:  callvirt   instance class [mscorlib]System.Reflection.MethodInfo [mscorlib]System.Type::GetMethod(string,
                                                                                                                  class [mscorlib]System.Type[])
      IL_024f:  stfld      class [mscorlib]System.Reflection.MethodInfo D.N.Proxy/RemoteMethods::Notify
      .line 203,204 : 17,65 ''
      IL_0254:  ldsflda    valuetype D.N.Proxy/RemoteMethods D.N.Proxy::remote
      IL_0259:  ldloc.s    'assembly'
      IL_025b:  ldstr      "Ukagaka.NET.Interfaces.IConfigure"
      IL_0260:  callvirt   instance class [mscorlib]System.Type [mscorlib]System.Reflection.Assembly::GetType(string)
      IL_0265:  ldstr      "configure"
      IL_026a:  ldc.i4.1
      IL_026b:  newarr     [mscorlib]System.Type
      IL_0270:  stloc.s    CS$0$0005
      IL_0272:  ldloc.s    CS$0$0005
      IL_0274:  ldc.i4.0
      IL_0275:  ldtoken    [mscorlib]System.IntPtr
      IL_027a:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
      IL_027f:  stelem.ref
      IL_0280:  ldloc.s    CS$0$0005
      IL_0282:  callvirt   instance class [mscorlib]System.Reflection.MethodInfo [mscorlib]System.Type::GetMethod(string,
                                                                                                                  class [mscorlib]System.Type[])
      IL_0287:  stfld      class [mscorlib]System.Reflection.MethodInfo D.N.Proxy/RemoteMethods::Configure
      .line 205,206 : 17,92 ''
      IL_028c:  ldsflda    valuetype D.N.Proxy/RemoteMethods D.N.Proxy::remote
      IL_0291:  ldloc.s    'assembly'
      IL_0293:  ldstr      "Ukagaka.NET.Interfaces.IExecute"
      IL_0298:  callvirt   instance class [mscorlib]System.Type [mscorlib]System.Reflection.Assembly::GetType(string)
      IL_029d:  ldstr      "execute"
      IL_02a2:  ldc.i4.2
      IL_02a3:  newarr     [mscorlib]System.Type
      IL_02a8:  stloc.s    CS$0$0006
      IL_02aa:  ldloc.s    CS$0$0006
      IL_02ac:  ldc.i4.0
      IL_02ad:  ldtoken    [mscorlib]System.IntPtr
      IL_02b2:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
      IL_02b7:  stelem.ref
      IL_02b8:  ldloc.s    CS$0$0006
      IL_02ba:  ldc.i4.1
      IL_02bb:  ldtoken    [mscorlib]System.Int32
      IL_02c0:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
      IL_02c5:  callvirt   instance class [mscorlib]System.Type [mscorlib]System.Type::MakeByRefType()
      IL_02ca:  stelem.ref
      IL_02cb:  ldloc.s    CS$0$0006
      IL_02cd:  callvirt   instance class [mscorlib]System.Reflection.MethodInfo [mscorlib]System.Type::GetMethod(string,
                                                                                                                  class [mscorlib]System.Type[])
      IL_02d2:  stfld      class [mscorlib]System.Reflection.MethodInfo D.N.Proxy/RemoteMethods::Execute
      .line 207,208 : 17,114 ''
      IL_02d7:  ldsflda    valuetype D.N.Proxy/RemoteMethods D.N.Proxy::remote
      IL_02dc:  ldloc.s    'assembly'
      IL_02de:  ldstr      "Ukagaka.NET.Interfaces.IGetUrl"
      IL_02e3:  callvirt   instance class [mscorlib]System.Type [mscorlib]System.Reflection.Assembly::GetType(string)
      IL_02e8:  ldstr      "geturl"
      IL_02ed:  ldc.i4.4
      IL_02ee:  newarr     [mscorlib]System.Type
      IL_02f3:  stloc.s    CS$0$0007
      IL_02f5:  ldloc.s    CS$0$0007
      IL_02f7:  ldc.i4.0
      IL_02f8:  ldtoken    [mscorlib]System.Int32
      IL_02fd:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
      IL_0302:  callvirt   instance class [mscorlib]System.Type [mscorlib]System.Type::MakeByRefType()
      IL_0307:  stelem.ref
      IL_0308:  ldloc.s    CS$0$0007
      IL_030a:  ldc.i4.1
      IL_030b:  ldtoken    [mscorlib]System.Int32
      IL_0310:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
      IL_0315:  stelem.ref
      IL_0316:  ldloc.s    CS$0$0007
      IL_0318:  ldc.i4.2
      IL_0319:  ldtoken    [mscorlib]System.Int32
      IL_031e:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
      IL_0323:  stelem.ref
      IL_0324:  ldloc.s    CS$0$0007
      IL_0326:  ldc.i4.3
      IL_0327:  ldtoken    [mscorlib]System.Int32
      IL_032c:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
      IL_0331:  stelem.ref
      IL_0332:  ldloc.s    CS$0$0007
      IL_0334:  callvirt   instance class [mscorlib]System.Reflection.MethodInfo [mscorlib]System.Type::GetMethod(string,
                                                                                                                  class [mscorlib]System.Type[])
      IL_0339:  stfld      class [mscorlib]System.Reflection.MethodInfo D.N.Proxy/RemoteMethods::GetUrl
      .line 209,210 : 17,96 ''
      IL_033e:  ldsflda    valuetype D.N.Proxy/RemoteMethods D.N.Proxy::remote
      IL_0343:  ldloc.s    'assembly'
      IL_0345:  ldstr      "Ukagaka.NET.Interfaces.IGetSchedule"
      IL_034a:  callvirt   instance class [mscorlib]System.Type [mscorlib]System.Reflection.Assembly::GetType(string)
      IL_034f:  ldstr      "getschedule"
      IL_0354:  ldc.i4.2
      IL_0355:  newarr     [mscorlib]System.Type
      IL_035a:  stloc.s    CS$0$0008
      IL_035c:  ldloc.s    CS$0$0008
      IL_035e:  ldc.i4.0
      IL_035f:  ldtoken    [mscorlib]System.IntPtr
      IL_0364:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
      IL_0369:  stelem.ref
      IL_036a:  ldloc.s    CS$0$0008
      IL_036c:  ldc.i4.1
      IL_036d:  ldtoken    [mscorlib]System.Int32
      IL_0372:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
      IL_0377:  callvirt   instance class [mscorlib]System.Type [mscorlib]System.Type::MakeByRefType()
      IL_037c:  stelem.ref
      IL_037d:  ldloc.s    CS$0$0008
      IL_037f:  callvirt   instance class [mscorlib]System.Reflection.MethodInfo [mscorlib]System.Type::GetMethod(string,
                                                                                                                  class [mscorlib]System.Type[])
      IL_0384:  stfld      class [mscorlib]System.Reflection.MethodInfo D.N.Proxy/RemoteMethods::GetSchedule
      .line 211,212 : 17,124 ''
      IL_0389:  ldsflda    valuetype D.N.Proxy/RemoteMethods D.N.Proxy::remote
      IL_038e:  ldloc.s    'assembly'
      IL_0390:  ldstr      "Ukagaka.NET.Interfaces.IGetUrlPost"
      IL_0395:  callvirt   instance class [mscorlib]System.Type [mscorlib]System.Reflection.Assembly::GetType(string)
      IL_039a:  ldstr      "geturlpost"
      IL_039f:  ldc.i4.3
      IL_03a0:  newarr     [mscorlib]System.Type
      IL_03a5:  stloc.s    CS$0$0009
      IL_03a7:  ldloc.s    CS$0$0009
      IL_03a9:  ldc.i4.0
      IL_03aa:  ldtoken    [mscorlib]System.IntPtr
      IL_03af:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
      IL_03b4:  stelem.ref
      IL_03b5:  ldloc.s    CS$0$0009
      IL_03b7:  ldc.i4.1
      IL_03b8:  ldtoken    [mscorlib]System.Int32
      IL_03bd:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
      IL_03c2:  callvirt   instance class [mscorlib]System.Type [mscorlib]System.Type::MakeByRefType()
      IL_03c7:  stelem.ref
      IL_03c8:  ldloc.s    CS$0$0009
      IL_03ca:  ldc.i4.2
      IL_03cb:  ldtoken    [mscorlib]System.Int32
      IL_03d0:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
      IL_03d5:  callvirt   instance class [mscorlib]System.Type [mscorlib]System.Type::MakeByRefType()
      IL_03da:  stelem.ref
      IL_03db:  ldloc.s    CS$0$0009
      IL_03dd:  callvirt   instance class [mscorlib]System.Reflection.MethodInfo [mscorlib]System.Type::GetMethod(string,
                                                                                                                  class [mscorlib]System.Type[])
      IL_03e2:  stfld      class [mscorlib]System.Reflection.MethodInfo D.N.Proxy/RemoteMethods::GetUrlPost
      IL_03e7:  leave.s    IL_0410

      .line 213,213 : 15,34 ''
    }  // end .try
    catch [mscorlib]System.Exception 
    {
      IL_03e9:  stloc.s    e
      .line 214,214 : 17,74 ''
      IL_03eb:  ldloc.s    e
      IL_03ed:  callvirt   instance class [mscorlib]System.Type [mscorlib]System.Exception::GetType()
      IL_03f2:  callvirt   instance string [mscorlib]System.Type::get_FullName()
      IL_03f7:  ldstr      "\n"
      IL_03fc:  ldloc.s    e
      IL_03fe:  callvirt   instance string [mscorlib]System.Exception::get_Message()
      IL_0403:  call       string [mscorlib]System.String::Concat(string,
                                                                  string,
                                                                  string)
      IL_0408:  call       valuetype [System.Windows.Forms]System.Windows.Forms.DialogResult [System.Windows.Forms]System.Windows.Forms.MessageBox::Show(string)
      IL_040d:  pop
      IL_040e:  leave.s    IL_0410

      .line 218,218 : 13,61 ''
    }  // end handler
    IL_0410:  ldloc.s    '<>8__locals3'
    IL_0412:  ldfld      string D.N.Proxy/'<>c__DisplayClass2'::selfdir
    IL_0417:  ldstr      "dngen.dll"
    IL_041c:  call       string [mscorlib]System.String::Concat(string,
                                                                string)
    IL_0421:  stloc.s    genpath
    .line 219,219 : 13,38 ''
    IL_0423:  ldloc.s    genpath
    IL_0425:  call       bool [mscorlib]System.IO.File::Exists(string)
    IL_042a:  brfalse    IL_04ff

    .line 221,221 : 21,76 ''
    .try
    {
      IL_042f:  ldloc.s    genpath
      IL_0431:  ldstr      ".ini"
      IL_0436:  call       string [mscorlib]System.IO.Path::ChangeExtension(string,
                                                                            string)
      IL_043b:  stloc.s    genconf
      .line 222,223 : 21,61 ''
      IL_043d:  ldsfld     class [mscorlib]System.AppDomain D.N.Proxy::domain
      IL_0442:  ldloc.s    genpath
      IL_0444:  ldstr      "D.N.Generator"
      IL_0449:  callvirt   instance object [mscorlib]System.AppDomain::CreateInstanceFromAndUnwrap(string,
                                                                                                   string)
      IL_044e:  stloc.s    generator
      .line 225,225 : 21,69 ''
      IL_0450:  ldloc.1
      IL_0451:  call       native int [mscorlib]System.Runtime.InteropServices.Marshal::StringToHGlobalAnsi(string)
      IL_0456:  stloc.s    h
      .line 226,226 : 21,47 ''
      IL_0458:  ldloc.1
      IL_0459:  callvirt   instance int32 [mscorlib]System.String::get_Length()
      IL_045e:  stloc.s    len
      .line 227,227 : 21,82 ''
      IL_0460:  ldsflda    valuetype D.N.Proxy/RemoteMethods D.N.Proxy::remote
      IL_0465:  ldfld      class [mscorlib]System.Reflection.MethodInfo D.N.Proxy/RemoteMethods::Load
      IL_046a:  ldloc.s    generator
      IL_046c:  ldc.i4.2
      IL_046d:  newarr     [mscorlib]System.Object
      IL_0472:  stloc.s    CS$0$0010
      IL_0474:  ldloc.s    CS$0$0010
      IL_0476:  ldc.i4.0
      IL_0477:  ldloc.s    h
      IL_0479:  box        [mscorlib]System.IntPtr
      IL_047e:  stelem.ref
      IL_047f:  ldloc.s    CS$0$0010
      IL_0481:  ldc.i4.1
      IL_0482:  ldloc.s    len
      IL_0484:  box        [mscorlib]System.Int32
      IL_0489:  stelem.ref
      IL_048a:  ldloc.s    CS$0$0010
      IL_048c:  callvirt   instance object [mscorlib]System.Reflection.MethodBase::Invoke(object,
                                                                                          object[])
      IL_0491:  pop
      .line 228,228 : 21,62 ''
      IL_0492:  ldloc.s    genconf
      IL_0494:  call       native int [mscorlib]System.Runtime.InteropServices.Marshal::StringToHGlobalAnsi(string)
      IL_0499:  stloc.s    h
      .line 229,229 : 21,42 ''
      IL_049b:  ldloc.s    genconf
      IL_049d:  callvirt   instance int32 [mscorlib]System.String::get_Length()
      IL_04a2:  stloc.s    len
      .line 230,230 : 21,85 ''
      IL_04a4:  ldsflda    valuetype D.N.Proxy/RemoteMethods D.N.Proxy::remote
      IL_04a9:  ldfld      class [mscorlib]System.Reflection.MethodInfo D.N.Proxy/RemoteMethods::Execute
      IL_04ae:  ldloc.s    generator
      IL_04b0:  ldc.i4.2
      IL_04b1:  newarr     [mscorlib]System.Object
      IL_04b6:  stloc.s    CS$0$0011
      IL_04b8:  ldloc.s    CS$0$0011
      IL_04ba:  ldc.i4.0
      IL_04bb:  ldloc.s    h
      IL_04bd:  box        [mscorlib]System.IntPtr
      IL_04c2:  stelem.ref
      IL_04c3:  ldloc.s    CS$0$0011
      IL_04c5:  ldc.i4.1
      IL_04c6:  ldloc.s    len
      IL_04c8:  box        [mscorlib]System.Int32
      IL_04cd:  stelem.ref
      IL_04ce:  ldloc.s    CS$0$0011
      IL_04d0:  callvirt   instance object [mscorlib]System.Reflection.MethodBase::Invoke(object,
                                                                                          object[])
      IL_04d5:  pop
      IL_04d6:  leave.s    IL_04ff

      .line 231,231 : 19,38 ''
    }  // end .try
    catch [mscorlib]System.Exception 
    {
      IL_04d8:  stloc.s    V_15
      .line 232,232 : 21,78 ''
      IL_04da:  ldloc.s    V_15
      IL_04dc:  callvirt   instance class [mscorlib]System.Type [mscorlib]System.Exception::GetType()
      IL_04e1:  callvirt   instance string [mscorlib]System.Type::get_FullName()
      IL_04e6:  ldstr      "\n"
      IL_04eb:  ldloc.s    V_15
      IL_04ed:  callvirt   instance string [mscorlib]System.Exception::get_Message()
      IL_04f2:  call       string [mscorlib]System.String::Concat(string,
                                                                  string,
                                                                  string)
      IL_04f7:  call       valuetype [System.Windows.Forms]System.Windows.Forms.DialogResult [System.Windows.Forms]System.Windows.Forms.MessageBox::Show(string)
      IL_04fc:  pop
      IL_04fd:  leave.s    IL_04ff

      .line 237,237 : 13,60 ''
    }  // end handler
    IL_04ff:  ldloc.s    '<>8__locals3'
    IL_0501:  ldfld      string D.N.Proxy/'<>c__DisplayClass2'::selfdir
    IL_0506:  ldstr      "dnutil.dll"
    IL_050b:  call       string [mscorlib]System.String::Concat(string,
                                                                string)
    IL_0510:  stloc.s    utilpath
    .line 238,238 : 13,39 ''
    IL_0512:  ldloc.s    utilpath
    IL_0514:  call       bool [mscorlib]System.IO.File::Exists(string)
    IL_0519:  brfalse    IL_05f8

    .line 240,241 : 21,60 ''
    .try
    {
      IL_051e:  ldsfld     class [mscorlib]System.AppDomain D.N.Proxy::domain
      IL_0523:  ldloc.s    utilpath
      IL_0525:  ldstr      "D.N.Manager"
      IL_052a:  callvirt   instance object [mscorlib]System.AppDomain::CreateInstanceFromAndUnwrap(string,
                                                                                                   string)
      IL_052f:  stsfld     object D.N.Proxy::utility
      .line 242,242 : 21,94 ''
      IL_0534:  ldsflda    valuetype D.N.Proxy/RemoteMethods D.N.Proxy::remote
      IL_0539:  ldfld      class [mscorlib]System.Reflection.MethodInfo D.N.Proxy/RemoteMethods::Load
      IL_053e:  ldsfld     object D.N.Proxy::utility
      IL_0543:  ldc.i4.2
      IL_0544:  newarr     [mscorlib]System.Object
      IL_0549:  stloc.s    CS$0$0012
      IL_054b:  ldloc.s    CS$0$0012
      IL_054d:  ldc.i4.0
      IL_054e:  ldsfld     native int [mscorlib]System.IntPtr::Zero
      IL_0553:  box        [mscorlib]System.IntPtr
      IL_0558:  stelem.ref
      IL_0559:  ldloc.s    CS$0$0012
      IL_055b:  ldc.i4.1
      IL_055c:  ldc.i4.0
      IL_055d:  box        [mscorlib]System.Int32
      IL_0562:  stelem.ref
      IL_0563:  ldloc.s    CS$0$0012
      IL_0565:  callvirt   instance object [mscorlib]System.Reflection.MethodBase::Invoke(object,
                                                                                          object[])
      IL_056a:  pop
      .line 243,244 : 21,62 ''
      IL_056b:  ldsfld     class [mscorlib]System.AppDomain D.N.Proxy::domain
      IL_0570:  ldloc.s    utilpath
      IL_0572:  ldstr      "D.N.Generator"
      IL_0577:  callvirt   instance object [mscorlib]System.AppDomain::CreateInstanceFromAndUnwrap(string,
                                                                                                   string)
      IL_057c:  stloc.s    V_17
      .line 245,245 : 21,76 ''
      IL_057e:  ldloc.0
      IL_057f:  ldstr      ".ini"
      IL_0584:  call       string [mscorlib]System.IO.Path::ChangeExtension(string,
                                                                            string)
      IL_0589:  stloc.s    config
      .line 246,246 : 21,68 ''
      IL_058b:  ldloc.s    config
      IL_058d:  call       native int [mscorlib]System.Runtime.InteropServices.Marshal::StringToHGlobalAnsi(string)
      IL_0592:  stloc.s    V_19
      .line 247,247 : 21,46 ''
      IL_0594:  ldloc.s    config
      IL_0596:  callvirt   instance int32 [mscorlib]System.String::get_Length()
      IL_059b:  stloc.s    V_20
      .line 248,248 : 21,85 ''
      IL_059d:  ldsflda    valuetype D.N.Proxy/RemoteMethods D.N.Proxy::remote
      IL_05a2:  ldfld      class [mscorlib]System.Reflection.MethodInfo D.N.Proxy/RemoteMethods::Execute
      IL_05a7:  ldloc.s    V_17
      IL_05a9:  ldc.i4.2
      IL_05aa:  newarr     [mscorlib]System.Object
      IL_05af:  stloc.s    CS$0$0013
      IL_05b1:  ldloc.s    CS$0$0013
      IL_05b3:  ldc.i4.0
      IL_05b4:  ldloc.s    V_19
      IL_05b6:  box        [mscorlib]System.IntPtr
      IL_05bb:  stelem.ref
      IL_05bc:  ldloc.s    CS$0$0013
      IL_05be:  ldc.i4.1
      IL_05bf:  ldloc.s    V_20
      IL_05c1:  box        [mscorlib]System.Int32
      IL_05c6:  stelem.ref
      IL_05c7:  ldloc.s    CS$0$0013
      IL_05c9:  callvirt   instance object [mscorlib]System.Reflection.MethodBase::Invoke(object,
                                                                                          object[])
      IL_05ce:  pop
      IL_05cf:  leave.s    IL_05f8

      .line 249,249 : 19,38 ''
    }  // end .try
    catch [mscorlib]System.Exception 
    {
      IL_05d1:  stloc.s    V_21
      .line 250,250 : 21,78 ''
      IL_05d3:  ldloc.s    V_21
      IL_05d5:  callvirt   instance class [mscorlib]System.Type [mscorlib]System.Exception::GetType()
      IL_05da:  callvirt   instance string [mscorlib]System.Type::get_FullName()
      IL_05df:  ldstr      "\n"
      IL_05e4:  ldloc.s    V_21
      IL_05e6:  callvirt   instance string [mscorlib]System.Exception::get_Message()
      IL_05eb:  call       string [mscorlib]System.String::Concat(string,
                                                                  string,
                                                                  string)
      IL_05f0:  call       valuetype [System.Windows.Forms]System.Windows.Forms.DialogResult [System.Windows.Forms]System.Windows.Forms.MessageBox::Show(string)
      IL_05f5:  pop
      IL_05f6:  leave.s    IL_05f8

      .line 256,257 : 17,56 ''
    }  // end handler
    .try
    {
      IL_05f8:  ldsfld     class [mscorlib]System.AppDomain D.N.Proxy::domain
      IL_05fd:  ldloc.s    '<>8__locals3'
      IL_05ff:  ldfld      string D.N.Proxy/'<>c__DisplayClass2'::selfdir
      IL_0604:  ldloc.3
      IL_0605:  call       string [mscorlib]System.String::Concat(string,
                                                                  string)
      IL_060a:  ldloc.s    mainClass
      IL_060c:  callvirt   instance object [mscorlib]System.AppDomain::CreateInstanceFromAndUnwrap(string,
                                                                                                   string)
      IL_0611:  stsfld     object D.N.Proxy::'instance'
      IL_0616:  leave.s    IL_0642

      .line 258,258 : 15,34 ''
    }  // end .try
    catch [mscorlib]System.Exception 
    {
      IL_0618:  stloc.s    V_22
      .line 259,259 : 17,74 ''
      IL_061a:  ldloc.s    V_22
      IL_061c:  callvirt   instance class [mscorlib]System.Type [mscorlib]System.Exception::GetType()
      IL_0621:  callvirt   instance string [mscorlib]System.Type::get_FullName()
      IL_0626:  ldstr      "\n"
      IL_062b:  ldloc.s    V_22
      IL_062d:  callvirt   instance string [mscorlib]System.Exception::get_Message()
      IL_0632:  call       string [mscorlib]System.String::Concat(string,
                                                                  string,
                                                                  string)
      IL_0637:  call       valuetype [System.Windows.Forms]System.Windows.Forms.DialogResult [System.Windows.Forms]System.Windows.Forms.MessageBox::Show(string)
      IL_063c:  pop
      .line 260,260 : 17,30 ''
      IL_063d:  ldc.i4.0
      IL_063e:  stloc.s    CS$1$0000
      IL_0640:  leave.s    IL_0644

      .line 279,279 : 13,25 ''
    }  // end handler
    IL_0642:  ldc.i4.1
    IL_0643:  ret

    .line 280,280 : 9,10 ''
    IL_0644:  ldloc.s    CS$1$0000
    IL_0646:  ret
  } // end of method Proxy::initialize

  .method private hidebysig static bool  finalize() cil managed
  {
    // �R�[�h �T�C�Y       78 (0x4e)
    .maxstack  3
    .line 298,298 : 13,39 ''
    IL_0000:  ldsfld     object D.N.Proxy::utility
    IL_0005:  brfalse.s  IL_0023

    .line 299,299 : 17,65 ''
    IL_0007:  ldsflda    valuetype D.N.Proxy/RemoteMethods D.N.Proxy::remote
    IL_000c:  ldfld      class [mscorlib]System.Reflection.MethodInfo D.N.Proxy/RemoteMethods::Unload
    IL_0011:  ldsfld     object D.N.Proxy::utility
    IL_0016:  ldnull
    IL_0017:  callvirt   instance object [mscorlib]System.Reflection.MethodBase::Invoke(object,
                                                                                        object[])
    IL_001c:  pop
    .line 300,300 : 17,38 ''
    IL_001d:  ldnull
    IL_001e:  stsfld     object D.N.Proxy::utility
    .line 302,302 : 13,40 ''
    IL_0023:  ldsfld     object D.N.Proxy::'instance'
    IL_0028:  brfalse.s  IL_0030

    .line 303,303 : 17,39 ''
    IL_002a:  ldnull
    IL_002b:  stsfld     object D.N.Proxy::'instance'
    .line 305,305 : 13,38 ''
    IL_0030:  ldsfld     class [mscorlib]System.AppDomain D.N.Proxy::domain
    IL_0035:  brfalse.s  IL_0047

    .line 306,306 : 17,48 ''
    IL_0037:  ldsfld     class [mscorlib]System.AppDomain D.N.Proxy::domain
    IL_003c:  call       void [mscorlib]System.AppDomain::Unload(class [mscorlib]System.AppDomain)
    .line 307,307 : 17,37 ''
    IL_0041:  ldnull
    IL_0042:  stsfld     class [mscorlib]System.AppDomain D.N.Proxy::domain
    .line 309,309 : 13,26 ''
    IL_0047:  call       void [mscorlib]System.GC::Collect()
    .line 311,311 : 13,25 ''
    IL_004c:  ldc.i4.1
    IL_004d:  ret
  } // end of method Proxy::finalize

  .method private hidebysig static bool  modopt([mscorlib]System.Runtime.CompilerServices.CallConvCdecl) logsend(int32 hWnd) cil managed
  {
    // �R�[�h �T�C�Y       2 (0x2)
    .vtentry 1:1
    .export [1] as logsend
    .maxstack  8
    .line 325,325 : 13,25 ''
    IL_0000:  ldc.i4.1
    IL_0001:  ret
  } // end of method Proxy::logsend

  .method private hidebysig static native int 
          modopt([mscorlib]System.Runtime.CompilerServices.CallConvCdecl) getversion(int32& len) cil managed
  {
    // �R�[�h �T�C�Y       153 (0x99)
    .vtentry 1:2
    .export [2] as getversion
    .maxstack  3
    .locals init ([0] object[] args,
             [1] native int h,
             [2] string response,
             [3] native int CS$1$0000,
             [4] object[] CS$0$0001)
    .line 339,339 : 13,37 ''
    IL_0000:  call       bool D.N.Proxy::initialize()
    IL_0005:  brtrue.s   IL_0010

    .line 340,340 : 17,25 ''
    IL_0007:  ldarg.0
    IL_0008:  ldc.i4.0
    IL_0009:  stind.i4
    .line 341,341 : 17,36 ''
    IL_000a:  ldsfld     native int [mscorlib]System.IntPtr::Zero
    IL_000f:  ret

    .line 344,344 : 17,54 ''
    .try
    {
      IL_0010:  ldc.i4.1
      IL_0011:  newarr     [mscorlib]System.Object
      IL_0016:  stloc.s    CS$0$0001
      IL_0018:  ldloc.s    CS$0$0001
      IL_001a:  ldc.i4.0
      IL_001b:  ldarg.0
      IL_001c:  ldind.i4
      IL_001d:  box        [mscorlib]System.Int32
      IL_0022:  stelem.ref
      IL_0023:  ldloc.s    CS$0$0001
      IL_0025:  stloc.0
      .line 345,345 : 17,90 ''
      IL_0026:  ldsflda    valuetype D.N.Proxy/RemoteMethods D.N.Proxy::remote
      IL_002b:  ldfld      class [mscorlib]System.Reflection.MethodInfo D.N.Proxy/RemoteMethods::GetVersion
      IL_0030:  ldsfld     object D.N.Proxy::'instance'
      IL_0035:  ldloc.0
      IL_0036:  callvirt   instance object [mscorlib]System.Reflection.MethodBase::Invoke(object,
                                                                                          object[])
      IL_003b:  unbox.any  [mscorlib]System.IntPtr
      IL_0040:  stloc.1
      .line 346,346 : 17,37 ''
      IL_0041:  ldarg.0
      IL_0042:  ldloc.0
      IL_0043:  ldc.i4.1
      IL_0044:  ldelem.ref
      IL_0045:  unbox.any  [mscorlib]System.Int32
      IL_004a:  stind.i4
      .line 347,347 : 17,26 ''
      IL_004b:  ldloc.1
      IL_004c:  stloc.3
      IL_004d:  leave.s    IL_0097

      .line 348,348 : 15,38 ''
    }  // end .try
    catch [mscorlib]System.Reflection.TargetException 
    {
      IL_004f:  pop
      .line 350,350 : 21,49 ''
      .try
      {
        IL_0050:  ldarg.0
        IL_0051:  ldsfld     string D.N.Proxy::protocol
        IL_0056:  callvirt   instance int32 [mscorlib]System.String::get_Length()
        IL_005b:  stind.i4
        .line 351,351 : 21,72 ''
        IL_005c:  ldsfld     string D.N.Proxy::protocol
        IL_0061:  call       native int [mscorlib]System.Runtime.InteropServices.Marshal::StringToHGlobalAnsi(string)
        IL_0066:  stloc.3
        IL_0067:  leave.s    IL_0097

        .line 352,352 : 19,24 ''
      }  // end .try
      catch [mscorlib]System.Object 
      {
        IL_0069:  pop
        .line 353,353 : 21,93 ''
        IL_006a:  ldsfld     string D.N.Proxy::protocol
        IL_006f:  ldstr      " 500 Internal Server Error\r\n\r\n"
        IL_0074:  call       string [mscorlib]System.String::Concat(string,
                                                                    string)
        IL_0079:  stloc.2
        .line 354,354 : 21,43 ''
        IL_007a:  ldarg.0
        IL_007b:  ldloc.2
        IL_007c:  callvirt   instance int32 [mscorlib]System.String::get_Length()
        IL_0081:  stind.i4
        .line 355,355 : 21,66 ''
        IL_0082:  ldloc.2
        IL_0083:  call       native int [mscorlib]System.Runtime.InteropServices.Marshal::StringToHGlobalAnsi(string)
        IL_0088:  stloc.3
        IL_0089:  leave.s    IL_0097

        .line 357,357 : 15,20 ''
      }  // end handler
    }  // end handler
    catch [mscorlib]System.Object 
    {
      IL_008b:  pop
      .line 358,358 : 17,25 ''
      IL_008c:  ldarg.0
      IL_008d:  ldc.i4.0
      IL_008e:  stind.i4
      .line 359,359 : 17,36 ''
      IL_008f:  ldsfld     native int [mscorlib]System.IntPtr::Zero
      IL_0094:  stloc.3
      IL_0095:  leave.s    IL_0097

      .line 361,361 : 9,10 ''
    }  // end handler
    IL_0097:  ldloc.3
    IL_0098:  ret
  } // end of method Proxy::getversion

  .method private hidebysig static bool  modopt([mscorlib]System.Runtime.CompilerServices.CallConvCdecl) load(native int h,
                                              int32 len) cil managed
  {
    // �R�[�h �T�C�Y       87 (0x57)
    .vtentry 1:3
    .export [3] as load
    .maxstack  5
    .locals init ([0] bool CS$1$0000,
             [1] object[] CS$0$0001)
    .line 375,375 : 13,37 ''
    IL_0000:  call       bool D.N.Proxy::initialize()
    IL_0005:  brtrue.s   IL_000f

    .line 376,376 : 17,40 ''
    IL_0007:  ldarg.0
    IL_0008:  call       void [mscorlib]System.Runtime.InteropServices.Marshal::FreeHGlobal(native int)
    .line 377,377 : 17,30 ''
    IL_000d:  ldc.i4.0
    IL_000e:  ret

    .line 380,380 : 17,97 ''
    .try
    {
      IL_000f:  ldsflda    valuetype D.N.Proxy/RemoteMethods D.N.Proxy::remote
      IL_0014:  ldfld      class [mscorlib]System.Reflection.MethodInfo D.N.Proxy/RemoteMethods::Load
      IL_0019:  ldsfld     object D.N.Proxy::'instance'
      IL_001e:  ldc.i4.2
      IL_001f:  newarr     [mscorlib]System.Object
      IL_0024:  stloc.1
      IL_0025:  ldloc.1
      IL_0026:  ldc.i4.0
      IL_0027:  ldarg.0
      IL_0028:  box        [mscorlib]System.IntPtr
      IL_002d:  stelem.ref
      IL_002e:  ldloc.1
      IL_002f:  ldc.i4.1
      IL_0030:  ldarg.1
      IL_0031:  box        [mscorlib]System.Int32
      IL_0036:  stelem.ref
      IL_0037:  ldloc.1
      IL_0038:  callvirt   instance object [mscorlib]System.Reflection.MethodBase::Invoke(object,
                                                                                          object[])
      IL_003d:  unbox.any  [mscorlib]System.Boolean
      IL_0042:  stloc.0
      IL_0043:  leave.s    IL_0055

      .line 381,381 : 15,38 ''
    }  // end .try
    catch [mscorlib]System.Reflection.TargetException 
    {
      IL_0045:  pop
      .line 382,382 : 17,40 ''
      IL_0046:  ldarg.0
      IL_0047:  call       void [mscorlib]System.Runtime.InteropServices.Marshal::FreeHGlobal(native int)
      .line 383,383 : 17,30 ''
      IL_004c:  ldc.i4.0
      IL_004d:  stloc.0
      IL_004e:  leave.s    IL_0055

      .line 384,384 : 15,20 ''
    }  // end handler
    catch [mscorlib]System.Object 
    {
      IL_0050:  pop
      .line 385,385 : 17,30 ''
      IL_0051:  ldc.i4.0
      IL_0052:  stloc.0
      IL_0053:  leave.s    IL_0055

      .line 387,387 : 9,10 ''
    }  // end handler
    IL_0055:  ldloc.0
    IL_0056:  ret
  } // end of method Proxy::load

  .method private hidebysig static bool  modopt([mscorlib]System.Runtime.CompilerServices.CallConvCdecl) unload() cil managed
  {
    // �R�[�h �T�C�Y       52 (0x34)
    .vtentry 1:4
    .export [4] as unload
    .maxstack  3
    .locals init ([0] bool result)
    .line 399,399 : 13,33 ''
    IL_0000:  ldc.i4.0
    IL_0001:  stloc.0
    .line 401,401 : 17,82 ''
    .try
    {
      IL_0002:  ldsflda    valuetype D.N.Proxy/RemoteMethods D.N.Proxy::remote
      IL_0007:  ldfld      class [mscorlib]System.Reflection.MethodInfo D.N.Proxy/RemoteMethods::Unload
      IL_000c:  ldsfld     object D.N.Proxy::'instance'
      IL_0011:  ldnull
      IL_0012:  callvirt   instance object [mscorlib]System.Reflection.MethodBase::Invoke(object,
                                                                                          object[])
      IL_0017:  unbox.any  [mscorlib]System.Boolean
      IL_001c:  stloc.0
      IL_001d:  leave.s    IL_0029

      .line 402,402 : 15,38 ''
    }  // end .try
    catch [mscorlib]System.Reflection.TargetException 
    {
      IL_001f:  pop
      .line 403,403 : 17,32 ''
      IL_0020:  ldc.i4.0
      IL_0021:  stloc.0
      IL_0022:  leave.s    IL_0029

      .line 404,404 : 15,20 ''
    }  // end handler
    catch [mscorlib]System.Object 
    {
      IL_0024:  pop
      .line 405,405 : 17,32 ''
      IL_0025:  ldc.i4.0
      IL_0026:  stloc.0
      IL_0027:  leave.s    IL_0029

      .line 407,407 : 13,35 ''
    }  // end handler
    IL_0029:  call       bool D.N.Proxy::finalize()
    IL_002e:  brtrue.s   IL_0032

    .line 408,408 : 17,30 ''
    IL_0030:  ldc.i4.0
    IL_0031:  ret

    .line 410,410 : 13,27 ''
    IL_0032:  ldloc.0
    IL_0033:  ret
  } // end of method Proxy::unload

  .method private hidebysig static native int 
          modopt([mscorlib]System.Runtime.CompilerServices.CallConvCdecl) 'request'(native int h,
                    int32& len) cil managed
  {
    // �R�[�h �T�C�Y       150 (0x96)
    .vtentry 1:5
    .export [5] as 'request'
    .maxstack  3
    .locals init ([0] object[] args,
             [1] string response,
             [2] string V_2,
             [3] native int CS$1$0000,
             [4] object[] CS$0$0001)
    .line 427,427 : 17,57 ''
    .try
    {
      IL_0000:  ldc.i4.2
      IL_0001:  newarr     [mscorlib]System.Object
      IL_0006:  stloc.s    CS$0$0001
      IL_0008:  ldloc.s    CS$0$0001
      IL_000a:  ldc.i4.0
      IL_000b:  ldarg.0
      IL_000c:  box        [mscorlib]System.IntPtr
      IL_0011:  stelem.ref
      IL_0012:  ldloc.s    CS$0$0001
      IL_0014:  ldc.i4.1
      IL_0015:  ldarg.1
      IL_0016:  ldind.i4
      IL_0017:  box        [mscorlib]System.Int32
      IL_001c:  stelem.ref
      IL_001d:  ldloc.s    CS$0$0001
      IL_001f:  stloc.0
      .line 428,428 : 17,80 ''
      IL_0020:  ldsflda    valuetype D.N.Proxy/RemoteMethods D.N.Proxy::remote
      IL_0025:  ldfld      class [mscorlib]System.Reflection.MethodInfo D.N.Proxy/RemoteMethods::Request
      IL_002a:  ldsfld     object D.N.Proxy::'instance'
      IL_002f:  ldloc.0
      IL_0030:  callvirt   instance object [mscorlib]System.Reflection.MethodBase::Invoke(object,
                                                                                          object[])
      IL_0035:  unbox.any  [mscorlib]System.IntPtr
      IL_003a:  starg.s    h
      .line 429,429 : 17,37 ''
      IL_003c:  ldarg.1
      IL_003d:  ldloc.0
      IL_003e:  ldc.i4.1
      IL_003f:  ldelem.ref
      IL_0040:  unbox.any  [mscorlib]System.Int32
      IL_0045:  stind.i4
      .line 430,430 : 17,26 ''
      IL_0046:  ldarg.0
      IL_0047:  stloc.3
      IL_0048:  leave.s    IL_0094

      .line 431,431 : 15,38 ''
    }  // end .try
    catch [mscorlib]System.Reflection.TargetException 
    {
      IL_004a:  pop
      .line 432,432 : 17,40 ''
      IL_004b:  ldarg.0
      IL_004c:  call       void [mscorlib]System.Runtime.InteropServices.Marshal::FreeHGlobal(native int)
      .line 433,433 : 17,89 ''
      IL_0051:  ldsfld     string D.N.Proxy::protocol
      IL_0056:  ldstr      " 500 Internal Server Error\r\n\r\n"
      IL_005b:  call       string [mscorlib]System.String::Concat(string,
                                                                  string)
      IL_0060:  stloc.1
      .line 434,434 : 17,39 ''
      IL_0061:  ldarg.1
      IL_0062:  ldloc.1
      IL_0063:  callvirt   instance int32 [mscorlib]System.String::get_Length()
      IL_0068:  stind.i4
      .line 435,435 : 17,62 ''
      IL_0069:  ldloc.1
      IL_006a:  call       native int [mscorlib]System.Runtime.InteropServices.Marshal::StringToHGlobalAnsi(string)
      IL_006f:  stloc.3
      IL_0070:  leave.s    IL_0094

      .line 436,436 : 15,20 ''
    }  // end handler
    catch [mscorlib]System.Object 
    {
      IL_0072:  pop
      .line 437,437 : 17,89 ''
      IL_0073:  ldsfld     string D.N.Proxy::protocol
      IL_0078:  ldstr      " 500 Internal Server Error\r\n\r\n"
      IL_007d:  call       string [mscorlib]System.String::Concat(string,
                                                                  string)
      IL_0082:  stloc.2
      .line 438,438 : 17,39 ''
      IL_0083:  ldarg.1
      IL_0084:  ldloc.2
      IL_0085:  callvirt   instance int32 [mscorlib]System.String::get_Length()
      IL_008a:  stind.i4
      .line 439,439 : 17,62 ''
      IL_008b:  ldloc.2
      IL_008c:  call       native int [mscorlib]System.Runtime.InteropServices.Marshal::StringToHGlobalAnsi(string)
      IL_0091:  stloc.3
      IL_0092:  leave.s    IL_0094

      .line 544,544 : 9,10 ''
    }  // end handler
    IL_0094:  ldloc.3
    IL_0095:  ret
  } // end of method Proxy::'request'

  .method private hidebysig static void  modopt([mscorlib]System.Runtime.CompilerServices.CallConvCdecl) notify(native int h,
                                                int32& len) cil managed
  {
    // �R�[�h �T�C�Y       75 (0x4b)
    .vtentry 1:6
    .export [6] as notify
    .maxstack  3
    .locals init ([0] object[] args,
             [1] object[] CS$0$0000)
    .line 557,557 : 17,57 ''
    .try
    {
      IL_0000:  ldc.i4.2
      IL_0001:  newarr     [mscorlib]System.Object
      IL_0006:  stloc.1
      IL_0007:  ldloc.1
      IL_0008:  ldc.i4.0
      IL_0009:  ldarg.0
      IL_000a:  box        [mscorlib]System.IntPtr
      IL_000f:  stelem.ref
      IL_0010:  ldloc.1
      IL_0011:  ldc.i4.1
      IL_0012:  ldarg.1
      IL_0013:  ldind.i4
      IL_0014:  box        [mscorlib]System.Int32
      IL_0019:  stelem.ref
      IL_001a:  ldloc.1
      IL_001b:  stloc.0
      .line 558,558 : 17,66 ''
      IL_001c:  ldsflda    valuetype D.N.Proxy/RemoteMethods D.N.Proxy::remote
      IL_0021:  ldfld      class [mscorlib]System.Reflection.MethodInfo D.N.Proxy/RemoteMethods::Notify
      IL_0026:  ldsfld     object D.N.Proxy::'instance'
      IL_002b:  ldloc.0
      IL_002c:  callvirt   instance object [mscorlib]System.Reflection.MethodBase::Invoke(object,
                                                                                          object[])
      IL_0031:  pop
      .line 559,559 : 17,37 ''
      IL_0032:  ldarg.1
      IL_0033:  ldloc.0
      IL_0034:  ldc.i4.1
      IL_0035:  ldelem.ref
      IL_0036:  unbox.any  [mscorlib]System.Int32
      IL_003b:  stind.i4
      IL_003c:  leave.s    IL_004a

      .line 560,560 : 15,38 ''
    }  // end .try
    catch [mscorlib]System.Reflection.TargetException 
    {
      IL_003e:  pop
      .line 561,561 : 17,40 ''
      IL_003f:  ldarg.0
      IL_0040:  call       void [mscorlib]System.Runtime.InteropServices.Marshal::FreeHGlobal(native int)
      .line 562,562 : 17,25 ''
      IL_0045:  ldarg.1
      IL_0046:  ldc.i4.0
      IL_0047:  stind.i4
      .line 563,563 : 17,24 ''
      IL_0048:  leave.s    IL_004a

      .line 565,565 : 9,10 ''
    }  // end handler
    IL_004a:  ret
  } // end of method Proxy::notify

  .method private hidebysig static void  modopt([mscorlib]System.Runtime.CompilerServices.CallConvCdecl) configure(native int hWnd) cil managed
  {
    // �R�[�h �T�C�Y       44 (0x2c)
    .vtentry 1:7
    .export [7] as configure
    .maxstack  5
    .locals init ([0] object[] CS$0$0000)
    .line 578,578 : 17,86 ''
    .try
    {
      IL_0000:  ldsflda    valuetype D.N.Proxy/RemoteMethods D.N.Proxy::remote
      IL_0005:  ldfld      class [mscorlib]System.Reflection.MethodInfo D.N.Proxy/RemoteMethods::Configure
      IL_000a:  ldsfld     object D.N.Proxy::'instance'
      IL_000f:  ldc.i4.1
      IL_0010:  newarr     [mscorlib]System.Object
      IL_0015:  stloc.0
      IL_0016:  ldloc.0
      IL_0017:  ldc.i4.0
      IL_0018:  ldarg.0
      IL_0019:  box        [mscorlib]System.IntPtr
      IL_001e:  stelem.ref
      IL_001f:  ldloc.0
      IL_0020:  callvirt   instance object [mscorlib]System.Reflection.MethodBase::Invoke(object,
                                                                                          object[])
      IL_0025:  pop
      IL_0026:  leave.s    IL_002b

      .line 579,579 : 15,38 ''
    }  // end .try
    catch [mscorlib]System.Reflection.TargetException 
    {
      IL_0028:  pop
      .line 580,580 : 17,24 ''
      IL_0029:  leave.s    IL_002b

      .line 582,582 : 9,10 ''
    }  // end handler
    IL_002b:  ret
  } // end of method Proxy::configure

  .method private hidebysig static native int 
          modopt([mscorlib]System.Runtime.CompilerServices.CallConvCdecl) execute(native int h,
                  int32& len) cil managed
  {
    // �R�[�h �T�C�Y       102 (0x66)
    .vtentry 1:8
    .export [8] as execute
    .maxstack  3
    .locals init ([0] object[] args,
             [1] native int CS$1$0000,
             [2] object[] CS$0$0001)
    .line 597,597 : 17,57 ''
    .try
    {
      IL_0000:  ldc.i4.2
      IL_0001:  newarr     [mscorlib]System.Object
      IL_0006:  stloc.2
      IL_0007:  ldloc.2
      IL_0008:  ldc.i4.0
      IL_0009:  ldarg.0
      IL_000a:  box        [mscorlib]System.IntPtr
      IL_000f:  stelem.ref
      IL_0010:  ldloc.2
      IL_0011:  ldc.i4.1
      IL_0012:  ldarg.1
      IL_0013:  ldind.i4
      IL_0014:  box        [mscorlib]System.Int32
      IL_0019:  stelem.ref
      IL_001a:  ldloc.2
      IL_001b:  stloc.0
      .line 598,598 : 17,80 ''
      IL_001c:  ldsflda    valuetype D.N.Proxy/RemoteMethods D.N.Proxy::remote
      IL_0021:  ldfld      class [mscorlib]System.Reflection.MethodInfo D.N.Proxy/RemoteMethods::Execute
      IL_0026:  ldsfld     object D.N.Proxy::'instance'
      IL_002b:  ldloc.0
      IL_002c:  callvirt   instance object [mscorlib]System.Reflection.MethodBase::Invoke(object,
                                                                                          object[])
      IL_0031:  unbox.any  [mscorlib]System.IntPtr
      IL_0036:  starg.s    h
      .line 599,599 : 17,37 ''
      IL_0038:  ldarg.1
      IL_0039:  ldloc.0
      IL_003a:  ldc.i4.1
      IL_003b:  ldelem.ref
      IL_003c:  unbox.any  [mscorlib]System.Int32
      IL_0041:  stind.i4
      .line 600,600 : 17,26 ''
      IL_0042:  ldarg.0
      IL_0043:  stloc.1
      IL_0044:  leave.s    IL_0064

      .line 601,601 : 15,38 ''
    }  // end .try
    catch [mscorlib]System.Reflection.TargetException 
    {
      IL_0046:  pop
      .line 602,602 : 17,40 ''
      IL_0047:  ldarg.0
      IL_0048:  call       void [mscorlib]System.Runtime.InteropServices.Marshal::FreeHGlobal(native int)
      .line 603,603 : 17,25 ''
      IL_004d:  ldarg.1
      IL_004e:  ldc.i4.0
      IL_004f:  stind.i4
      .line 604,604 : 17,36 ''
      IL_0050:  ldsfld     native int [mscorlib]System.IntPtr::Zero
      IL_0055:  stloc.1
      IL_0056:  leave.s    IL_0064

      .line 605,605 : 15,20 ''
    }  // end handler
    catch [mscorlib]System.Object 
    {
      IL_0058:  pop
      .line 606,606 : 17,25 ''
      IL_0059:  ldarg.1
      IL_005a:  ldc.i4.0
      IL_005b:  stind.i4
      .line 607,607 : 17,36 ''
      IL_005c:  ldsfld     native int [mscorlib]System.IntPtr::Zero
      IL_0061:  stloc.1
      IL_0062:  leave.s    IL_0064

      .line 609,609 : 9,10 ''
    }  // end handler
    IL_0064:  ldloc.1
    IL_0065:  ret
  } // end of method Proxy::execute

  .method private hidebysig static native int 
          modopt([mscorlib]System.Runtime.CompilerServices.CallConvCdecl) geturl(int32& len,
                 int32 year,
                 int32 month,
                 int32 day) cil managed
  {
    // �R�[�h �T�C�Y       113 (0x71)
    .vtentry 1:9
    .export [9] as geturl
    .maxstack  3
    .locals init ([0] object[] args,
             [1] native int h,
             [2] native int CS$1$0000,
             [3] object[] CS$0$0001)
    .line 628,628 : 17,72 ''
    .try
    {
      IL_0000:  ldc.i4.4
      IL_0001:  newarr     [mscorlib]System.Object
      IL_0006:  stloc.3
      IL_0007:  ldloc.3
      IL_0008:  ldc.i4.0
      IL_0009:  ldarg.0
      IL_000a:  ldind.i4
      IL_000b:  box        [mscorlib]System.Int32
      IL_0010:  stelem.ref
      IL_0011:  ldloc.3
      IL_0012:  ldc.i4.1
      IL_0013:  ldarg.1
      IL_0014:  box        [mscorlib]System.Int32
      IL_0019:  stelem.ref
      IL_001a:  ldloc.3
      IL_001b:  ldc.i4.2
      IL_001c:  ldarg.2
      IL_001d:  box        [mscorlib]System.Int32
      IL_0022:  stelem.ref
      IL_0023:  ldloc.3
      IL_0024:  ldc.i4.3
      IL_0025:  ldarg.3
      IL_0026:  box        [mscorlib]System.Int32
      IL_002b:  stelem.ref
      IL_002c:  ldloc.3
      IL_002d:  stloc.0
      .line 629,629 : 17,86 ''
      IL_002e:  ldsflda    valuetype D.N.Proxy/RemoteMethods D.N.Proxy::remote
      IL_0033:  ldfld      class [mscorlib]System.Reflection.MethodInfo D.N.Proxy/RemoteMethods::GetUrl
      IL_0038:  ldsfld     object D.N.Proxy::'instance'
      IL_003d:  ldloc.0
      IL_003e:  callvirt   instance object [mscorlib]System.Reflection.MethodBase::Invoke(object,
                                                                                          object[])
      IL_0043:  unbox.any  [mscorlib]System.IntPtr
      IL_0048:  stloc.1
      .line 630,630 : 17,37 ''
      IL_0049:  ldarg.0
      IL_004a:  ldloc.0
      IL_004b:  ldc.i4.0
      IL_004c:  ldelem.ref
      IL_004d:  unbox.any  [mscorlib]System.Int32
      IL_0052:  stind.i4
      .line 631,631 : 17,26 ''
      IL_0053:  ldloc.1
      IL_0054:  stloc.2
      IL_0055:  leave.s    IL_006f

      .line 632,632 : 15,38 ''
    }  // end .try
    catch [mscorlib]System.Reflection.TargetException 
    {
      IL_0057:  pop
      .line 633,633 : 17,25 ''
      IL_0058:  ldarg.0
      IL_0059:  ldc.i4.0
      IL_005a:  stind.i4
      .line 634,634 : 17,36 ''
      IL_005b:  ldsfld     native int [mscorlib]System.IntPtr::Zero
      IL_0060:  stloc.2
      IL_0061:  leave.s    IL_006f

      .line 635,635 : 15,20 ''
    }  // end handler
    catch [mscorlib]System.Object 
    {
      IL_0063:  pop
      .line 636,636 : 17,25 ''
      IL_0064:  ldarg.0
      IL_0065:  ldc.i4.0
      IL_0066:  stind.i4
      .line 637,637 : 17,36 ''
      IL_0067:  ldsfld     native int [mscorlib]System.IntPtr::Zero
      IL_006c:  stloc.2
      IL_006d:  leave.s    IL_006f

      .line 639,639 : 9,10 ''
    }  // end handler
    IL_006f:  ldloc.2
    IL_0070:  ret
  } // end of method Proxy::geturl

  .method private hidebysig static native int 
          modopt([mscorlib]System.Runtime.CompilerServices.CallConvCdecl) getschedule(native int h,
                      int32& len) cil managed
  {
    // �R�[�h �T�C�Y       102 (0x66)
    .vtentry 1:10
    .export [10] as getschedule
    .maxstack  3
    .locals init ([0] object[] args,
             [1] native int CS$1$0000,
             [2] object[] CS$0$0001)
    .line 654,654 : 17,56 ''
    .try
    {
      IL_0000:  ldc.i4.2
      IL_0001:  newarr     [mscorlib]System.Object
      IL_0006:  stloc.2
      IL_0007:  ldloc.2
      IL_0008:  ldc.i4.0
      IL_0009:  ldarg.0
      IL_000a:  box        [mscorlib]System.IntPtr
      IL_000f:  stelem.ref
      IL_0010:  ldloc.2
      IL_0011:  ldc.i4.1
      IL_0012:  ldarg.1
      IL_0013:  ldind.i4
      IL_0014:  box        [mscorlib]System.Int32
      IL_0019:  stelem.ref
      IL_001a:  ldloc.2
      IL_001b:  stloc.0
      .line 655,655 : 17,84 ''
      IL_001c:  ldsflda    valuetype D.N.Proxy/RemoteMethods D.N.Proxy::remote
      IL_0021:  ldfld      class [mscorlib]System.Reflection.MethodInfo D.N.Proxy/RemoteMethods::GetSchedule
      IL_0026:  ldsfld     object D.N.Proxy::'instance'
      IL_002b:  ldloc.0
      IL_002c:  callvirt   instance object [mscorlib]System.Reflection.MethodBase::Invoke(object,
                                                                                          object[])
      IL_0031:  unbox.any  [mscorlib]System.IntPtr
      IL_0036:  starg.s    h
      .line 656,656 : 17,37 ''
      IL_0038:  ldarg.1
      IL_0039:  ldloc.0
      IL_003a:  ldc.i4.1
      IL_003b:  ldelem.ref
      IL_003c:  unbox.any  [mscorlib]System.Int32
      IL_0041:  stind.i4
      .line 657,657 : 17,26 ''
      IL_0042:  ldarg.0
      IL_0043:  stloc.1
      IL_0044:  leave.s    IL_0064

      .line 658,658 : 15,38 ''
    }  // end .try
    catch [mscorlib]System.Reflection.TargetException 
    {
      IL_0046:  pop
      .line 659,659 : 17,40 ''
      IL_0047:  ldarg.0
      IL_0048:  call       void [mscorlib]System.Runtime.InteropServices.Marshal::FreeHGlobal(native int)
      .line 660,660 : 17,25 ''
      IL_004d:  ldarg.1
      IL_004e:  ldc.i4.0
      IL_004f:  stind.i4
      .line 661,661 : 17,36 ''
      IL_0050:  ldsfld     native int [mscorlib]System.IntPtr::Zero
      IL_0055:  stloc.1
      IL_0056:  leave.s    IL_0064

      .line 662,662 : 15,20 ''
    }  // end handler
    catch [mscorlib]System.Object 
    {
      IL_0058:  pop
      .line 663,663 : 17,25 ''
      IL_0059:  ldarg.1
      IL_005a:  ldc.i4.0
      IL_005b:  stind.i4
      .line 664,664 : 17,36 ''
      IL_005c:  ldsfld     native int [mscorlib]System.IntPtr::Zero
      IL_0061:  stloc.1
      IL_0062:  leave.s    IL_0064

      .line 666,666 : 9,10 ''
    }  // end handler
    IL_0064:  ldloc.1
    IL_0065:  ret
  } // end of method Proxy::getschedule

  .method private hidebysig static native int 
          modopt([mscorlib]System.Runtime.CompilerServices.CallConvCdecl) geturlpost(native int h,
                     int32& len,
                     int32& 'method') cil managed
  {
    // �R�[�h �T�C�Y       128 (0x80)
    .vtentry 1:11
    .export [11] as geturlpost
    .maxstack  3
    .locals init ([0] object[] args,
             [1] native int CS$1$0000,
             [2] object[] CS$0$0001)
    .line 682,682 : 17,65 ''
    .try
    {
      IL_0000:  ldc.i4.3
      IL_0001:  newarr     [mscorlib]System.Object
      IL_0006:  stloc.2
      IL_0007:  ldloc.2
      IL_0008:  ldc.i4.0
      IL_0009:  ldarg.0
      IL_000a:  box        [mscorlib]System.IntPtr
      IL_000f:  stelem.ref
      IL_0010:  ldloc.2
      IL_0011:  ldc.i4.1
      IL_0012:  ldarg.1
      IL_0013:  ldind.i4
      IL_0014:  box        [mscorlib]System.Int32
      IL_0019:  stelem.ref
      IL_001a:  ldloc.2
      IL_001b:  ldc.i4.2
      IL_001c:  ldarg.2
      IL_001d:  ldind.i4
      IL_001e:  box        [mscorlib]System.Int32
      IL_0023:  stelem.ref
      IL_0024:  ldloc.2
      IL_0025:  stloc.0
      .line 683,683 : 17,83 ''
      IL_0026:  ldsflda    valuetype D.N.Proxy/RemoteMethods D.N.Proxy::remote
      IL_002b:  ldfld      class [mscorlib]System.Reflection.MethodInfo D.N.Proxy/RemoteMethods::GetUrlPost
      IL_0030:  ldsfld     object D.N.Proxy::'instance'
      IL_0035:  ldloc.0
      IL_0036:  callvirt   instance object [mscorlib]System.Reflection.MethodBase::Invoke(object,
                                                                                          object[])
      IL_003b:  unbox.any  [mscorlib]System.IntPtr
      IL_0040:  starg.s    h
      .line 684,684 : 17,37 ''
      IL_0042:  ldarg.1
      IL_0043:  ldloc.0
      IL_0044:  ldc.i4.1
      IL_0045:  ldelem.ref
      IL_0046:  unbox.any  [mscorlib]System.Int32
      IL_004b:  stind.i4
      .line 685,685 : 17,40 ''
      IL_004c:  ldarg.2
      IL_004d:  ldloc.0
      IL_004e:  ldc.i4.2
      IL_004f:  ldelem.ref
      IL_0050:  unbox.any  [mscorlib]System.Int32
      IL_0055:  stind.i4
      .line 686,686 : 17,26 ''
      IL_0056:  ldarg.0
      IL_0057:  stloc.1
      IL_0058:  leave.s    IL_007e

      .line 687,687 : 15,38 ''
    }  // end .try
    catch [mscorlib]System.Reflection.TargetException 
    {
      IL_005a:  pop
      .line 688,688 : 17,40 ''
      IL_005b:  ldarg.0
      IL_005c:  call       void [mscorlib]System.Runtime.InteropServices.Marshal::FreeHGlobal(native int)
      .line 689,689 : 17,25 ''
      IL_0061:  ldarg.1
      IL_0062:  ldc.i4.0
      IL_0063:  stind.i4
      .line 690,690 : 17,28 ''
      IL_0064:  ldarg.2
      IL_0065:  ldc.i4.0
      IL_0066:  stind.i4
      .line 691,691 : 17,36 ''
      IL_0067:  ldsfld     native int [mscorlib]System.IntPtr::Zero
      IL_006c:  stloc.1
      IL_006d:  leave.s    IL_007e

      .line 692,692 : 15,20 ''
    }  // end handler
    catch [mscorlib]System.Object 
    {
      IL_006f:  pop
      .line 693,693 : 17,25 ''
      IL_0070:  ldarg.1
      IL_0071:  ldc.i4.0
      IL_0072:  stind.i4
      .line 694,694 : 17,28 ''
      IL_0073:  ldarg.2
      IL_0074:  ldc.i4.0
      IL_0075:  stind.i4
      .line 695,695 : 17,36 ''
      IL_0076:  ldsfld     native int [mscorlib]System.IntPtr::Zero
      IL_007b:  stloc.1
      IL_007c:  leave.s    IL_007e

      .line 697,697 : 9,10 ''
    }  // end handler
    IL_007e:  ldloc.1
    IL_007f:  ret
  } // end of method Proxy::geturlpost

} // end of class D.N.Proxy


// =============================================================

// *********** �t�A�Z���u�����������܂��� ***********************
// �x��: Win32 ���\�[�X �t�@�C�� H:\workspace\dnproxy_sepif\dnproxy\bin\Release\dnproxy.res ��쐬���܂����B

