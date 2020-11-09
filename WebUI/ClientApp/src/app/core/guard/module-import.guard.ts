/**
 * function used to throw an error if you try to import a module multiple times. This is the recommended way by Google.
 * @param parentModule Tha parent module (reference to the module itself, for instance CoreModule)
 * @param moduleName String that represents the module name that you want to load (for instance 'CoreModule')
 */
export function ModuleImportGuard(parentModule: any, moduleName: string) {
  if (parentModule) {
    throw new Error(`${moduleName} has already been loaded. Import Core modules in the AppModule only.`);
  }
}

// export abstract class ModuleImportGuard {
//     protected constructor(targetModule: any) {
//         if (targetModule) {
//             throw new Error(`${targetModule.constructor.name} has already been loaded.`);
//         }
//     }
// }
