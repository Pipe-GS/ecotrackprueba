import React, { useState, useEffect } from 'react';
import { MapContainer, TileLayer, Marker, Popup, useMapEvent } from 'react-leaflet';
import L from 'leaflet';
import 'leaflet/dist/leaflet.css';
import './styles.css';

const link = document.createElement('link');
link.href = 'https://fonts.googleapis.com/css2?family=Poppins:wght@400;600&family=Montserrat:wght@400;600&display=swap';
link.rel = 'stylesheet';
document.head.appendChild(link);

const markerIcon = new L.Icon({
    iconUrl: require('leaflet/dist/images/marker-icon.png'),
    iconRetinaUrl: require('leaflet/dist/images/marker-icon-2x.png'),
    shadowUrl: require('leaflet/dist/images/marker-shadow.png'),
    iconSize: [25, 41],
    iconAnchor: [12, 41],
    popupAnchor: [1, -34],
    shadowSize: [41, 41],
});

const MapaPequeño = () => {
    const [position, setPosition] = useState([13.68935, -89.18718]);
    const [address, setAddress] = useState("");
    const [savedLocation, setSavedLocation] = useState(null);

    useEffect(() => {
        document.body.classList.add('estilo2');
        

        // Cargar ubicación guardada desde localStorage (si existe)
        const storedLocation = JSON.parse(localStorage.getItem('savedLocation'));
        if (storedLocation) {
            setSavedLocation(storedLocation);
            setPosition(storedLocation.position);
            setAddress(storedLocation.address);
        }

        return () => {
            document.body.classList.remove('estilo2');
        };
    }, []);

    const handleSearch = () => {
        fetch(`https://nominatim.openstreetmap.org/search?q=${address}&format=json&addressdetails=1`)
            .then(response => response.json())
            .then(data => {
                if (data.length > 0) {
                    const lat = data[0].lat;
                    const lon = data[0].lon;
                    setPosition([lat, lon]);
                    setAddress(data[0].display_name);
                    setSavedLocation({ position: [lat, lon], address: data[0].display_name });
                } else {
                    alert('Dirección no encontrada');
                }
            })
            .catch(error => console.error('Error:', error));
    };

    const HandleMapClick = () => {
        useMapEvent('click', (event) => {
            const { lat, lng } = event.latlng;
            setPosition([lat, lng]);

            fetch(`https://nominatim.openstreetmap.org/reverse?lat=${lat}&lon=${lng}&format=json`)
                .then(response => response.json())
                .then(data => {
                    if (data && data.display_name) {
                        setAddress(data.display_name);
                        setSavedLocation({ position: [lat, lng], address: data.display_name });
                    }
                })
                .catch(error => console.error('Error en la geocodificación inversa:', error));
        });

        return null;
    };

    const handleSaveLocation = () => {
        if (savedLocation) {
            localStorage.setItem('savedLocation', JSON.stringify(savedLocation));
            alert(`Ubicación guardada: ${savedLocation.address}`);
        } else {
            alert('No hay ubicación para guardar');
        }
    };

    const handleKeyPress = (event) => {
        if (event.key === "Enter") {
            handleSearch();
        }
    };

    return (
        <div className="map-container-small">
            <div className="background-image"></div>
            <div className="mancha"></div>
            <div className="mancha2"></div>
            <header className="Ubiheader">
                <h1 className="logo-text">E C O T R A C K</h1>
            </header>
            <h1 className="map-title">Proporcionanos tu Ubicación</h1>
            <p className="map-subtitle">Esto nos ayudará a brindarte el servicio más acertado a tus necesidades</p>
            <div className="input-mapa-container">
                <input
                    className="map-input"
                    type="text"
                    value={address}
                    onChange={(e) => setAddress(e.target.value)}
                    onKeyPress={handleKeyPress}
                    placeholder="Ingresa una dirección"
                />
                <button className="map-button" onClick={handleSearch}>
                    🔍
                </button>
            </div>
            <div className="map-container">
                <MapContainer 
                    center={position} 
                    zoom={13} 
                    className="map" 
                    doubleClickZoom={false}
                >
                    <TileLayer
                        url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
                        attribution='&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
                    />
                    <HandleMapClick />
                    <Marker position={position} icon={markerIcon}>
                        <Popup>
                            {address || "Ubicación seleccionada"}
                        </Popup>
                    </Marker>
                </MapContainer>
            </div>
            <button className="map-button" onClick={handleSaveLocation}>Guardar Ubicación</button>
            <footer className="footer">
        <span>© SummerTime Coders</span>
      </footer>
    </div>
        
        
    );
};

export default MapaPequeño;
