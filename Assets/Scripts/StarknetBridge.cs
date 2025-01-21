using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public static class StarknetBridge
{
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_WEBGL)
    private const string dllName = "__Internal";
#else
    private const string dllName = "starknet_bridge";
#endif

    [DllImport(dllName)]
    public static extern KeyPair generate_key_pair();

    [DllImport(dllName)]
    public static extern string get_argent_contract_address(string public_key, string classHash);

    [DllImport(dllName)]
    public static extern Signatures get_argent_deploy_account_signature(SignatureDeployInput input,
        int chain_int_id);

    [DllImport(dllName)]
    public static extern string get_open_zeppelin_contract_address(string public_key, string classHash);

    // 1 = Main net, 2 = Test Net(deprecate), 3 = Test Net2(deprecate), 4 = Katana,5 = Sepolia default is Sepolia
    [DllImport(dllName)]
    public static extern Signatures get_open_zeppelin_deploy_account_signature(SignatureDeployInput input,
        int chain_int_id, string classHash);

    [DllImport(dllName)]
    public static extern Signatures get_general_signature(SignatureInput input, IntPtr[] strings, int count,
        string selector, int cairoVersion, int chainId);
    
    // [DllImport(dllName)] (deprecate)
    // public static extern Signatures get_estimate_fee_sig(SignatureInput input, IntPtr[] strings, int count,
    //     string selector, int cairoVersion, int chainId);
}

