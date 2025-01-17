from flask import Flask, request, jsonify
from flask_cors import CORS
from flask_sqlalchemy import SQLAlchemy
from flask_bcrypt import Bcrypt
from flask_login import LoginManager, login_user, logout_user, login_required
import cv2
import face_recognition
import numpy as np
from db import data_base, Usuario

app = Flask(__name__)

app.config['SQLALCHEMY_DATABASE_URI'] = 'postgresql://postgres:123456@localhost/ejercicio_flask'
app.config['SECRET_KEY'] = '123456'

data_base.init_app(app)
bcrypt = Bcrypt(app)
CORS(app, origins="*")

Login_manager = LoginManager()
Login_manager.init_app(app)
Login_manager.login_view = 'login'

@Login_manager.user_loader
def load_user(user_id):
    return Usuario.query.get(int(user_id))

def capture_face():
    video_capture = cv2.VideoCapture(0)
    ret, frame = video_capture.read()
    video_capture.release()
    if not ret:
        return None
    rgb_frame = frame[:, :, ::-1]  # Convert BGR to RGB
    face_locations = face_recognition.face_locations(rgb_frame)
    if len(face_locations) == 0:
        return None
    face_encodings = face_recognition.face_encodings(rgb_frame, face_locations)
    return face_encodings[0]

@app.route('/registrar', methods=['POST'])
def registrar():
    data = request.json
    email = data['email']
    password = data['password']

    face_encoding = capture_face()
    if face_encoding is None:
        return jsonify({"mensaje": "No se detectó un rostro. Por favor, intente nuevamente."}), 400
    
    usuario = Usuario(email=email, face_encoding=face_encoding.tobytes())
    usuario.set_password(password)
    data_base.session.add(usuario)
    data_base.session.commit()
    return jsonify({"mensaje": "Usuario registrado exitosamente"}), 201

@app.route('/login', methods=['POST'])
def login():
    face_encoding = capture_face()
    if face_encoding is None:
        return jsonify({"mensaje": "No se detectó un rostro. Por favor, intente nuevamente."}), 400

    usuarios = Usuario.query.all()
    for usuario in usuarios:
        known_face_encoding = np.frombuffer(usuario.face_encoding, dtype=np.float64)
        match = face_recognition.compare_faces([known_face_encoding], face_encoding)
        if match[0]:
            login_user(usuario)
            return jsonify({"mensaje": "Usuario logueado exitosamente"}), 200

    return jsonify({"mensaje": "Reconocimiento facial fallido. Inténtelo de nuevo."}), 401

@app.route('/logout', methods=['POST'])
@login_required
def logout():
    logout_user()
    return jsonify({"mensaje": "Usuario deslogueado exitosamente"}), 200

if __name__ == '__main__':
    with app.app_context():
        data_base.create_all()
    app.run(debug=True)
