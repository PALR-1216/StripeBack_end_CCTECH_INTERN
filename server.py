from flask import Flask, request, jsonify
from flask_cors import CORS
import stripe

# Initialize Flask application
app = Flask(__name__)
CORS(app)
# Set your Stripe secret key
stripe.api_key = 'sk_test_51OrLO8Rq3xShrsxlJiSjvPjtHYapSWs18z3CaVhvos3ZPPdJ7Hdcsztc04UoBB1zPWsC2JpxFJ3Ny8A30NTiiCWE005z658TNa'

# Endpoint to create a payment intent and retrieve client secret
@app.route('/create-payment-intent', methods=['POST'])
def create_payment_intent():
    try:
        # Create a payment intent
        payment_intent = stripe.PaymentIntent.create(
            amount=1000,  # Amount in cents
            currency='usd'
        )

        # Return the client secret
        return jsonify({'clientSecret': payment_intent.client_secret}), 200
    except Exception as e:
        return jsonify({'error': str(e)}), 500

# Run the Flask app
if __name__ == '__main__':
    app.run(debug=True)

