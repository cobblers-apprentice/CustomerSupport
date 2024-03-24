import { NgModule } from "@angular/core";
import { PreloadAllModules, RouterModule, Routes } from "@angular/router";
import { RouteProtection } from "./services/route-protection";
import { LoginComponent } from "./forms/login/login.component";

const routes: Routes = [
  { path: "", redirectTo: "form", pathMatch: "full" },
  { path: 'login', component: LoginComponent }, 

  {
    path: "",
    canActivate: [RouteProtection], 
    children: [
      {path: "form", loadChildren: () => import("./forms/form/from-module").then((f) => f.FormModule)},
    ]
  }
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
