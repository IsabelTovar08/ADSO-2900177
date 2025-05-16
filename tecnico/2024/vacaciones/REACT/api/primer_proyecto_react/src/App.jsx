import { useState, useEffect } from 'react'
import './App.css'
import axios from 'axios'  // Importación correcta

function App() {
  const [data, setData] = useState([])

  useEffect(() => {
    axios.get('http://127.0.0.1:5000/api')  // URL corregida
      .then(response => {
        setData(response.data.users)
      })
      .catch(error => {
        console.error("Error " + error);
      })
  }, []);

  return (
    <>
      <h1>Información</h1>
      <ul>
        {data.map((item, index) => (
          <li key={index}>{item}</li>
        ))}
      </ul>

      <div className="targetContainer">
        <div className='target'>
          <div className='tittleTarget'>Login</div>
          <div className="subTittleContainer">
            <div className='subTittle'>Esta es la descripción del login con react</div>
          </div>
          <form action="">
            <div className='form-group'>
              <input type="email" id="email" name="email" placeholder="Ingrese su email" required />
              <input type="password" id="password" name="password" placeholder="Contraseña" required />
              <div className="recoverPassword"><span>Recuperar Contraseña</span></div>
              <button type="submit" className='buttonLogin'>Ingresar</button>
            </div>
          </form>
          <div className="footerForm">
            <div>--O inicia sesión con--</div>
            <div className="containerIcons">
              <div className='icon'>
                Google
              </div>
              <div className='icon'>
                Facebook
              </div>
              <div className='icon'>
                Github
              </div>
            </div>
          </div>
          <div>No tienes una cuenta? <span>Inicia Sesión</span></div>
        </div>
      </div>
    </>
  )
}

export default App

