from flask import Flask, request, jsonify
from flask_cors import CORS

app = Flask(__name__)
CORS(app, origins="*")  # Aplica CORS aquí

@app.route('/api', methods=['GET'])
def users():
    return jsonify(
        {
         "users":[
                "isabel",
                "isa@gmail.com"
         ]
        }
    )

if __name__ == '__main__':
    app.run(debug=True)