import json
from models.urb import Urb
from utils.in_memory_datastore import urbs_data_store

# Seeder JSON string
urbs_json = """
            [
                { "id": 1, "name": "Basil" },
                { "id": 2, "name": "Rosemary" },
                { "id": 3, "name": "Thyme" },
                { "id": 4, "name": "Sage" },
                { "id": 5, "name": "Mint" },
                { "id": 6, "name": "Parsley" },
                { "id": 7, "name": "Cilantro" },
                { "id": 8, "name": "Dill" },
                { "id": 9, "name": "Oregano" },
                { "id": 10, "name": "Chives" }
            ]
            """

def seed_urbs():
    # Parse the JSON string
    urbs = json.loads(urbs_json)
    # Clear existing data
    urbs_data_store.clear()
    # Populate the data store
    for urb in urbs:
        urbs_data_store.append(urb)