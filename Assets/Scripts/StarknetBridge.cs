using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

    #region Relative Data Structure

    [StructLayout(LayoutKind.Sequential)]
    public struct SignatureInputV5
    {
        public string private_key;
        public string self_contract_address;
        public string nonce;
        public string max_fee;
        public IntPtr transactions;
        public int transaction_count;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct KeyPair
    {
        public string public_key;
        public string private_key;

        public KeyPair(string pub, string priv)
        {
            this.public_key = pub;
            this.private_key = priv;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SignatureRes
    {
        public string r_sig;
        public string s_sig;

        public SignatureRes(string r_sig, string s_sig)
        {
            this.r_sig = r_sig;
            this.s_sig = s_sig;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SignatureInput
    {
        public string private_key;
        public string self_contract_address;
        public string to;
        public string nonce;
        public string max_fee;

        public SignatureInput(string private_key, string self_contract_address, string to, string nonce, string max_fee)
        {
            this.private_key = private_key;
            this.self_contract_address = self_contract_address;
            this.to = to;
            this.nonce = nonce;
            this.max_fee = max_fee;
        }
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct SignatureDeployInput
    {
        public string private_key;
        public string public_key;
        public string nonce;
        public string max_fee;
        public string salt;
    }

    public enum StarknetVersion
    {
        V2,
        V3
    }

    #endregion

    #region DllImport

    public static class StarknetBridgeController
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
        public static extern SignatureRes get_argent_deploy_account_signature(SignatureDeployInput input,
            int chain_int_id);

        [DllImport(dllName)]
        public static extern string get_open_zeppelin_contract_address(string public_key, string classHash);

        // 1 = Main net, 2 = Test Net(Deprecated), 3 = Test Net2(Deprecated), 4 = Katana, 5 = Sepolia, default is Sepolia
        [DllImport(dllName)]
        public static extern SignatureRes get_open_zeppelin_deploy_account_signature(SignatureDeployInput input,
            int chain_int_id, string classHash);

        // 1 = Main net, 2 = Test Net(Deprecated), 3 = Test Net2(Deprecated), 4 = Katana, 5 = Sepolia, default is Sepolia
        [DllImport(dllName)]
        public static extern SignatureRes get_open_zeppelin_deploy_account_signature_v3(SignatureDeployInput input,
            int chain_int_id, string classHash, ulong gas, ulong gasPriceHigh, ulong gasPriceLow);


        [DllImport(dllName)]
        public static extern SignatureRes get_general_signature(SignatureInput input, IntPtr[] strings, int count,
            string selector, int cairoVersion, int chainId);

        // Unique 0 = false, 1 = true
        [DllImport(dllName)]
        public static extern SignatureRes get_deploy_contract_signature(SignatureInput input, int cairoVersion,
            int chainId,
            int unique, string salt, string classHash);

        [DllImport(dllName)]
        public static extern SignatureRes get_estimate_fee_sig(SignatureInput input, IntPtr[] strings, int count,
            string selector, int cairoVersion, int chainId);

        [DllImport(dllName)]
        public static extern SignatureRes get_general_signature_V5(SignatureInputV5 input, int cairoVersion,
            int chainId);

        [DllImport(dllName)]
        public static extern string get_tx_hash_v1(SignatureInputV5 input, int cairoVersion,
            int chainId);

        [DllImport(dllName)]
        public static extern string get_hash_on_elements(IntPtr[] strings, int count);

        [DllImport(dllName)]
        public static extern SignatureRes get_general_signature_v3(SignatureInputV5 input, int cairoVersion,
            int chainId, ulong gas, ulong low, ulong high);

        [DllImport(dllName)]
        public static extern string get_tx_hash_v3(SignatureInputV5 input, int cairoVersion,
            int chainId, ulong gas, ulong low, ulong high);

        /// <summary>
        /// Compute the poseidon hash many
        /// </summary>
        /// <param name="strings"></param>
        /// <param name="stringListCount"></param>
        /// <returns></returns>
        [DllImport(dllName)]
        public static extern string get_poseidon_hash_many_on_elements(IntPtr[] strings, int stringListCount);

        /// <summary>
        /// Get the hash value with big int string
        /// </summary>
        /// <param name="selector"></param>
        /// <returns></returns>
        [DllImport(dllName)]
        public static extern string get_hex_from_name(string selector);

        [DllImport(dllName)]
        public static extern SignatureRes execute_outside_signature(string privateKey, string msgHash);
    }

    #endregion