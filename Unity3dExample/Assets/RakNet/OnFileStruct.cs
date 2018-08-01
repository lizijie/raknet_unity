/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 2.0.12
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */

namespace RakNet {

using System;
using System.Runtime.InteropServices;

public class OnFileStruct : IDisposable {
  private HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal OnFileStruct(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(OnFileStruct obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~OnFileStruct() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          RakNetPINVOKE.delete_OnFileStruct(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
    }
  }

    private bool fileDataIsCached = false;
    private byte[] fileDataCache;

  public uint fileIndex {
    set {
      RakNetPINVOKE.OnFileStruct_fileIndex_set(swigCPtr, value);
    } 
    get {
      uint ret = RakNetPINVOKE.OnFileStruct_fileIndex_get(swigCPtr);
      return ret;
    } 
  }

  public string fileName {
    set {
      RakNetPINVOKE.OnFileStruct_fileName_set(swigCPtr, value);
    } 
    get {
      string ret = RakNetPINVOKE.OnFileStruct_fileName_get(swigCPtr);
      return ret;
    } 
  }

  public byte[] fileData {
	set 
	{
	    	fileDataCache=value;
		fileDataIsCached = true;
		SetFileData (value, value.Length);    
	}

        get
        {
            byte[] returnArray;
            if (!fileDataIsCached)
            {
                IntPtr cPtr = RakNetPINVOKE.OnFileStruct_fileData_get (swigCPtr);
                int len = (int) byteLengthOfThisFile;
		if (len<=0)
		{
			return null;
		}
                returnArray = new byte[len];
                byte[] marshalArray = new byte[len];
                Marshal.Copy(cPtr, marshalArray, 0, len);
                marshalArray.CopyTo(returnArray, 0);
                fileDataCache = returnArray;
                fileDataIsCached = true;
            }
            else
            {
                returnArray = fileDataCache;
            }
            return returnArray;
        }
 
  }

  public uint byteLengthOfThisFile {
    set {
      RakNetPINVOKE.OnFileStruct_byteLengthOfThisFile_set(swigCPtr, value);
    } 
    get {
      uint ret = RakNetPINVOKE.OnFileStruct_byteLengthOfThisFile_get(swigCPtr);
      return ret;
    } 
  }

  public uint bytesDownloadedForThisFile {
    set {
      RakNetPINVOKE.OnFileStruct_bytesDownloadedForThisFile_set(swigCPtr, value);
    } 
    get {
      uint ret = RakNetPINVOKE.OnFileStruct_bytesDownloadedForThisFile_get(swigCPtr);
      return ret;
    } 
  }

  public ushort setID {
    set {
      RakNetPINVOKE.OnFileStruct_setID_set(swigCPtr, value);
    } 
    get {
      ushort ret = RakNetPINVOKE.OnFileStruct_setID_get(swigCPtr);
      return ret;
    } 
  }

  public uint numberOfFilesInThisSet {
    set {
      RakNetPINVOKE.OnFileStruct_numberOfFilesInThisSet_set(swigCPtr, value);
    } 
    get {
      uint ret = RakNetPINVOKE.OnFileStruct_numberOfFilesInThisSet_get(swigCPtr);
      return ret;
    } 
  }

  public uint byteLengthOfThisSet {
    set {
      RakNetPINVOKE.OnFileStruct_byteLengthOfThisSet_set(swigCPtr, value);
    } 
    get {
      uint ret = RakNetPINVOKE.OnFileStruct_byteLengthOfThisSet_get(swigCPtr);
      return ret;
    } 
  }

  public uint bytesDownloadedForThisSet {
    set {
      RakNetPINVOKE.OnFileStruct_bytesDownloadedForThisSet_set(swigCPtr, value);
    } 
    get {
      uint ret = RakNetPINVOKE.OnFileStruct_bytesDownloadedForThisSet_get(swigCPtr);
      return ret;
    } 
  }

  public FileListNodeContext context {
    set {
      RakNetPINVOKE.OnFileStruct_context_set(swigCPtr, FileListNodeContext.getCPtr(value));
    } 
    get {
      IntPtr cPtr = RakNetPINVOKE.OnFileStruct_context_get(swigCPtr);
      FileListNodeContext ret = (cPtr == IntPtr.Zero) ? null : new FileListNodeContext(cPtr, false);
      return ret;
    } 
  }

  public SystemAddress senderSystemAddress {
    set {
      RakNetPINVOKE.OnFileStruct_senderSystemAddress_set(swigCPtr, SystemAddress.getCPtr(value));
    } 
    get {
      IntPtr cPtr = RakNetPINVOKE.OnFileStruct_senderSystemAddress_get(swigCPtr);
      SystemAddress ret = (cPtr == IntPtr.Zero) ? null : new SystemAddress(cPtr, false);
      return ret;
    } 
  }

  public RakNetGUID senderGuid {
    set {
      RakNetPINVOKE.OnFileStruct_senderGuid_set(swigCPtr, RakNetGUID.getCPtr(value));
    } 
    get {
      IntPtr cPtr = RakNetPINVOKE.OnFileStruct_senderGuid_get(swigCPtr);
      RakNetGUID ret = (cPtr == IntPtr.Zero) ? null : new RakNetGUID(cPtr, false);
      return ret;
    } 
  }

  public OnFileStruct() : this(RakNetPINVOKE.new_OnFileStruct(), true) {
  }

  private void SetFileData(byte[] inByteArray, int numBytes) {
    RakNetPINVOKE.OnFileStruct_SetFileData(swigCPtr, inByteArray, numBytes);
  }

}

}
