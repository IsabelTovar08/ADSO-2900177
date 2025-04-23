import { Component } from '@angular/core';
import { Router, RouterLink, RouterOutlet } from '@angular/router';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatListModule} from '@angular/material/list';
import {MatButtonModule, MatIconButton} from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import {MatIconModule} from '@angular/material/icon';
import { AuthService } from '../../../../services/auth-service.service';

@Component({
  selector: 'app-dashboard',
  imports: [
    RouterOutlet, MatSidenavModule, MatListModule, RouterLink, MatButtonModule,  MatCardModule, MatIconModule,
  ],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent {
  constructor(private router: Router, private authService: AuthService) {}

  goToConfig() {
    this.router.navigate(['/config']);
  }
  selectedSection: string = 'cabello';

  onSectionSelected(section: string) {
    this.selectedSection = section;
  }

  isSidenavOpen = false; // Inicialmente el sidenav está cerrado

  // Método para alternar el estado del sidenav
  toggleSidenav() {
    this.isSidenavOpen = !this.isSidenavOpen;
  }
  logout() {
    this.authService.logout();
  }
}
