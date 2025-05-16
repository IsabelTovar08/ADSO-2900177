import { Routes } from '@angular/router';
import { ListaPostsComponent } from './Components/Posts/lista-posts/lista-posts.component';
import { ListaAlbumsComponent } from './Components/albums/lista-albums/lista-albums.component';
import { ListUsersComponent } from './Components/users/list-users/list-users.component';

export const routes: Routes = [
    {path: '', redirectTo: 'posts', pathMatch: 'full' },
    {path: 'posts', component: ListaPostsComponent},
    {path: 'albums', component: ListaAlbumsComponent},
    {path: 'users', component: ListUsersComponent},

];
