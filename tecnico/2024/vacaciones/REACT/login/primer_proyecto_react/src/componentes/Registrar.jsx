import { useState, useEffect } from 'react'
import '../App.css'
import axios from 'axios'  // Importación correcta
import { useNavigate } from 'react-router-dom';

function Registrar() {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const navigate = useNavigate();

    const subnit = async (e) => {
        e.preventDefault();
        try {
            const response = await axios.post('http://127.0.0.1:5000/registrar', { email, password });
            alert(response.data.mensaje);
            navigate('/');
        }catch(error){
            alert('Registro Fallido' + error);
        }
    }


  return (
    <>

      <div className="targetContainer">
        <div className='target'>
          <div className='tittleTarget'>Registrar</div>
          <div className="subTittleContainer">
            <div className='subTittle'>Esta es la descripción del login con react</div>
          </div>
          <form action="" onSubmit={subnit}>
            <div className='form-group'>
                <input type="email" id="email" name="email" value={email} onChange={(e) => setEmail(e.target.value)} placeholder="Ingrese su email" required />
                <input type="password" id="password" name="password" value={password} onChange={(e) => setPassword(e.target.value)} placeholder="Contraseña" required />
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
          <div>Ya tienes una cuenta? <span>Inicia Sesión</span></div>
        </div>
      </div>
    </>
  )
}

export default Registrar

