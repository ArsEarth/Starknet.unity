<p align="center">
  <img src="/Documentation/Image/logo.png" alt="Starknet.unity logo" width="200px"/>
</p>

# Starknet.unity

This project is a package for unity, it provides the CSharp with the Starknet interaction capability .

- Updated to support Starknet 0.11.0
- Easy to use like Starknet.js
- Direct interaction with your Starknet contract
- Multiple platforms supported

## Installation

1. Download the latest from release
2. Import the package file (.unitypackage) from `Asset -> Import Package` in unity editor
3. Now the Starknet.unity package is in your Assets
4. **( IOS ONLY )** Download the plugin [Download](https://drive.google.com/file/d/1mQCQrVblRRJtNVcbPIckMjlhIDpKNq-X/view?usp=sharing), and put it in `Assets/Plugins/IOS`, reopen the Unity

**Note: Most time the release page may not be updated timely, please check the source code for more detail.**

## How to use

In any script, use a static class `StarknetBridge` to access the required methods. Currently, all methods working and has been tested in Sepolia Testnet.

- `generate_key_pair() -> KeyPair`

  > Generate the public key and private key

- `Signatures get_open_zeppelin_deploy_account_signature(SignatureDeployInput input, int chain_int_id, string classHash);`

  > Generate the contract address for open zeppelin 

- `get_open_zeppelin_deploy_account_signature(string publickey,string classHash) -> BigInt String`

  > Get the deploy account signatures

- `get_argent_contract_address(string publickey,string classHash) -> BigInt String`

  >   > Generate the contract address for argent 

- `get_argent_deploy_account_signature(SignatureAccountDeployInput input) -> Signatures`

  > Generate signatures for argent deployment of new account

- ` get_general_signature(SignatureInput input, IntPtr[] strings, int count,string selector, int cairoVersion, int chainId); -> Signatures`
  > Get the invoke transaction signatures


## Example Intro
You can check the sample scene in `Scenes -> Starknet.unity.examples`

In the example, a simple chain manager is implemented, there are two main core demo:
 1.  Deploy new contract on chain
 2.  Make transaction (transfer eth from one contract to another contract)

- `TestDeployNewAccount`
  > You could check how to create new account, how to transfer eth to this new account, then deploy the account on Sepolia. 

## Updating Road Map

| Milestone                       | Detail                                                                        | Status |
| ------------------------------- | ----------------------------------------------------------------------------- | ------ |
| Basic Account Created           | Generate the key pair and relative contract address                           | ✔️     |
| Generate Deploy Signatures      | Create the relative signature for deploying new account                       | ✔️     |
| Support the new ARGENT protocal | Update the new call data structure to correct the signature | ✔️     |
| Android Support                 | Support the Android Build                                                     | ✔️     |
| Deploy the Account on Chain     | Use the csharp script to deploy the created account                           | ✔️     |
| Generate Transaction signatures | Generate transaction signatures for calling contract                          | ✔️     |
| Relative RPC handlers           | Make the request from CSharp side                                             | ✔️     |
| Example Added                   | The example for make transaction                                              | ✔️     |
| IOS Support                     | Support the IOS Build                                                         |  ✔️    |
| Starknet Support 0.11.0 (**Aug/1/2024**)                    | Support the Starknet newest version         |  ✔️    |
| Starknet Execute Outside                   | Outside Execution         |  pending    |

## Contributors

|                                          | Detail                                         |
| ---------------------------------------- | ---------------------------------------------- |
| [@XAR](https://github.com/xarlabs) | The organizer                                  |
| [@Joel Lai](https://github.com/joellai)  | Unity script coding and overwrite Starknet API |
| [@Bill Lee](https://github.com/tgyf007)  | Starknet RPC request and response digging      |

## License

Licensed under the [MIT license](https://github.com/joellai/Starknet.unity/blob/main/LICENSE).
