import { NgModule } from "@angular/core";
import { PreloadAllModules, RouterModule, Routes } from "@angular/router";

const routes: Routes = [
  { path: "", redirectTo: "form", pathMatch: "full" },
  {path: "form", loadChildren: () => import("./forms/form/from-module").then((f) => f.FormModule)}
  // {
  //   path: "login",
  //   loadChildren: () =>
  //     import("./framework/forms/user-management/login/login.module").then(
  //       (m) => m.LoginModule
  //     ),
  // },
  // {
  //   path: "",
  //   component: CustomLayoutComponent,
  //   canActivateChild: [AuthGuard],
  //   children: [
  //     {
  //       path: "home",
  //       loadChildren: () =>
  //         import("./forms/home/home.module").then((m) => m.HomeModule),
  //     }     
  //   ]
  // }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, {
      // preloadingStrategy: NoPreloading,
      preloadingStrategy: PreloadAllModules,
      scrollPositionRestoration: "enabled",
      anchorScrolling: "enabled",
      useHash: true,
    }),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule { }
