from fastapi import APIRouter
from typing import List
from models.urb import Urb
from utils.in_memory_datastore import urbs_data_store

router = APIRouter()

@router.get("/urbs", response_model=List[Urb])
async def read_urbs():
    return urbs_data_store