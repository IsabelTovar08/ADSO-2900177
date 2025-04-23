async function login() {
    const response = await fetch('http://localhost:5150/api/Auth/login', {
        method : 'POST',
        headers:  {'Content-Type': 'application/json' },
        body: JSON.stringify({
            userName: document.getElementById('email').value,
            password: document.getElementById('password').value
        })
    });

    if(response.ok){
        const data = await response.json();
        const token = data.token;

        localStorage.setItem('jwt', token);

        alert("Login exitoso");
        // location.href = 'index.html';

        const roles = getUserRoles();

        if (roles.includes('Admin')) {
          console.log("Es admin");
        } else {
          console.log("No Es admin");
        
        }
    }
    else{
        alert("Error de autenticación");
    }
}
function getUserRoles() {
    const token = localStorage.getItem('jwt');
    console.log(token);
    if (!token) return [];
  
    const payload = parseJwt(token);
    const roles = payload?.role;
    console.log("roles");
    console.log("roles" + roles);
  
    if (!roles) return [];

  
    return Array.isArray(roles) ? roles : [roles]; // Asegurar que siempre sea array
  }
  
function parseJwt(token) {
    try {
      const base64Payload = token.split('.')[1];
      const decodedPayload = atob(base64Payload);
      return JSON.parse(decodedPayload);
    } catch (e) {
      console.error('Error al decodificar el token:', e);
      return null;
    }
  }
  