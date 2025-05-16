from flask_sqlalchemy import SQLAlchemy
from flask_bcrypt import Bcrypt
from flask_login import UserMixin

data_base = SQLAlchemy()
bcrypt = Bcrypt()

class Usuario(data_base.Model, UserMixin):
    __tablename__ = 'users'
    id = data_base.Column(data_base.Integer, primary_key=True)
    email = data_base.Column(data_base.String(100), unique=True)
    password = data_base.Column(data_base.String(100))
    
    # def __init__(self, email, password):
    #     self.email = email
    #     self.password = bcrypt.generate_password_hash(password).decode('utf-8')
        
    def set_password(self, password):
        self.password = bcrypt.generate_password_hash(password).decode('utf-8')
        
    def check_password(self, password):
        return bcrypt.check_password_hash(self.password, password)