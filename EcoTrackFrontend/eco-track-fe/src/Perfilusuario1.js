import React from 'react';
import { useNavigate } from 'react-router-dom';  
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faCalendarAlt, faClipboardList, faBell, faSearch } from '@fortawesome/free-solid-svg-icons';
import './styles.css'; 
import MenuDesplegable from './MenuDesplegable'; // Importa el componente del menú

const InformacionUsuario = () => {
  const navigate = useNavigate(); //hook useNavigate

  const handleEdit = () => {
    console.log("Editando información del usuario...");
  };

  const handleBack = () => {
    navigate(-1); // Retrocede a la pantalla anterior
  };

  return (
    <div className="container">
      <header className="header">
        <h2>Información del Usuario</h2>
        <button className="back-button" onClick={handleBack}>Atrás</button>
      </header>

      <div className="informacion-usuario-container">
        <img src="ProgramacionII/EcoTrackFrontend/eco-track-fe/src/pantalla10.jpg" alt="Usuario" width="100" height="100" />
        <div className="user-details">
          <h2>Brendan Moore</h2>
          <p>Currently in London, UK</p>
          <div className="user-info">
            <p>Ubicación: San Salvador</p>
            <p>Hora: GMT 0000</p>
            <p>Correo: aaaaa@gmail.com</p>
          </div>
          <button className="edit-button" onClick={handleEdit}>EDITAR</button>
        </div>
      </div>

      {/* Barra inferior con íconos */}
      <div className="bottom-nav">
        <div className="nav-icon">
          <FontAwesomeIcon icon={faCalendarAlt} />
          <span>Agenda</span>
        </div>
        <div className="nav-icon">
          <FontAwesomeIcon icon={faClipboardList} />
          <span>Tasks</span>
        </div>

        {/* menú desplegable */}
        <MenuDesplegable /> 

        <div className="nav-icon">
          <FontAwesomeIcon icon={faBell} />
          <span>Notification</span>
        </div>
        <div className="nav-icon">
          <FontAwesomeIcon icon={faSearch} />
          <span>Search</span>
        </div>
      </div>
    </div>
  );
};

export default InformacionUsuario;
