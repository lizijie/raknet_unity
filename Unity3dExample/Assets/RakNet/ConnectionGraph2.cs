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

public class ConnectionGraph2 : PluginInterface2 {
  private HandleRef swigCPtr;

  internal ConnectionGraph2(IntPtr cPtr, bool cMemoryOwn) : base(RakNetPINVOKE.ConnectionGraph2_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(ConnectionGraph2 obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~ConnectionGraph2() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          RakNetPINVOKE.delete_ConnectionGraph2(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

    public bool GetConnectionListForRemoteSystem(RakNetGUID remoteSystemGuid, SystemAddress[] saOut, RakNetGUID[] guidOut, ref uint inOutLength)
    {
        uint minLength = inOutLength;
        if (guidOut.Length < minLength)
        { minLength = (uint)guidOut.Length; }

        if (saOut.Length < minLength)
        { minLength = (uint)saOut.Length; }

        RakNetListRakNetGUID passListGUID = new RakNetListRakNetGUID();
        RakNetListSystemAddress passListSystemAddress = new RakNetListSystemAddress();

        bool returnVal = GetConnectionListForRemoteSystemHelper(remoteSystemGuid, passListSystemAddress, passListGUID, ref inOutLength);

        if (inOutLength< minLength)
        { minLength = (uint)inOutLength;}

        for (int i = 0; i < minLength; i++)
        {
            guidOut[i] = passListGUID[i];
            saOut[i] = passListSystemAddress[i];
        }
        return returnVal;
    }
    
    public void GetParticipantList(RakNetGUID[] participantList)
    {
			RakNetListRakNetGUID passListGUID = new RakNetListRakNetGUID();
			GetParticipantListHelper(passListGUID);
			for (int i = 0; i < participantList.Length && i < passListGUID.Size(); i++)
			{
			  participantList[i] = passListGUID[i];
			}
    }


  public static ConnectionGraph2 GetInstance() {
    IntPtr cPtr = RakNetPINVOKE.ConnectionGraph2_GetInstance();
    ConnectionGraph2 ret = (cPtr == IntPtr.Zero) ? null : new ConnectionGraph2(cPtr, false);
    return ret;
  }

  public static void DestroyInstance(ConnectionGraph2 i) {
    RakNetPINVOKE.ConnectionGraph2_DestroyInstance(ConnectionGraph2.getCPtr(i));
  }

  public ConnectionGraph2() : this(RakNetPINVOKE.new_ConnectionGraph2(), true) {
  }

  public bool GetConnectionListForRemoteSystem(RakNetGUID remoteSystemGuid, SystemAddress saOut, RakNetGUID guidOut, out uint outLength) {
    bool ret = RakNetPINVOKE.ConnectionGraph2_GetConnectionListForRemoteSystem(swigCPtr, RakNetGUID.getCPtr(remoteSystemGuid), SystemAddress.getCPtr(saOut), RakNetGUID.getCPtr(guidOut), out outLength);
    if (RakNetPINVOKE.SWIGPendingException.Pending) throw RakNetPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool ConnectionExists(RakNetGUID g1, RakNetGUID g2) {
    bool ret = RakNetPINVOKE.ConnectionGraph2_ConnectionExists(swigCPtr, RakNetGUID.getCPtr(g1), RakNetGUID.getCPtr(g2));
    if (RakNetPINVOKE.SWIGPendingException.Pending) throw RakNetPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public ushort GetPingBetweenSystems(RakNetGUID g1, RakNetGUID g2) {
    ushort ret = RakNetPINVOKE.ConnectionGraph2_GetPingBetweenSystems(swigCPtr, RakNetGUID.getCPtr(g1), RakNetGUID.getCPtr(g2));
    if (RakNetPINVOKE.SWIGPendingException.Pending) throw RakNetPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public RakNetGUID GetLowestAveragePingSystem() {
    RakNetGUID ret = new RakNetGUID(RakNetPINVOKE.ConnectionGraph2_GetLowestAveragePingSystem(swigCPtr), true);
    return ret;
  }

  public void SetAutoProcessNewConnections(bool b) {
    RakNetPINVOKE.ConnectionGraph2_SetAutoProcessNewConnections(swigCPtr, b);
  }

  public bool GetAutoProcessNewConnections() {
    bool ret = RakNetPINVOKE.ConnectionGraph2_GetAutoProcessNewConnections(swigCPtr);
    return ret;
  }

  public void AddParticipant(SystemAddress systemAddress, RakNetGUID rakNetGUID) {
    RakNetPINVOKE.ConnectionGraph2_AddParticipant(swigCPtr, SystemAddress.getCPtr(systemAddress), RakNetGUID.getCPtr(rakNetGUID));
    if (RakNetPINVOKE.SWIGPendingException.Pending) throw RakNetPINVOKE.SWIGPendingException.Retrieve();
  }

  private bool GetConnectionListForRemoteSystemHelper(RakNetGUID remoteSystemGuid, RakNetListSystemAddress saOut, RakNetListRakNetGUID guidOut, ref uint inOutLength) {
    bool ret = RakNetPINVOKE.ConnectionGraph2_GetConnectionListForRemoteSystemHelper(swigCPtr, RakNetGUID.getCPtr(remoteSystemGuid), RakNetListSystemAddress.getCPtr(saOut), RakNetListRakNetGUID.getCPtr(guidOut), ref inOutLength);
    if (RakNetPINVOKE.SWIGPendingException.Pending) throw RakNetPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  private void GetParticipantListHelper(RakNetListRakNetGUID guidOut) {
    RakNetPINVOKE.ConnectionGraph2_GetParticipantListHelper(swigCPtr, RakNetListRakNetGUID.getCPtr(guidOut));
  }

}

}
