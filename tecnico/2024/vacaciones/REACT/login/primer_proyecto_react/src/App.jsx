import React from 'react';

import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Login from './componentes/Login';

import Home from './componentes/Home';
import Registrar from './componentes/Registrar';
// import Home from './componentes/Home';
// import Login from './componentes/Login';

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/login" element={< Login />} />
        <Route path="/registrar" element={<Registrar />} />
        <Route path="/" element={<Home />} />
      </Routes>
    </Router>
  );
}

export default App;
