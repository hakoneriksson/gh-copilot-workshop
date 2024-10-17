from fastapi import APIRouter, HTTPException
from typing import List

from models.urb import Urb
from models.basket_of_urbs import BasketOfUrbs
from utils.in_memory_datastore import baskets_data_store, urbs_data_store

router = APIRouter()

@router.get("/baskets", response_model=List[BasketOfUrbs])
async def read_baskets():
    return list(baskets_data_store.values())

@router.post("/baskets", response_model=BasketOfUrbs, status_code=201)
async def create_basket(basket: BasketOfUrbs):
    raise HTTPException(status_code=400, detail="Basket is not ready to be sent")

@router.post("/baskets/{basket_id}/urbs", response_model=BasketOfUrbs, status_code=201)
async def add_urb_to_basket(basket_id: int, urb_id: int):
    raise HTTPException(status_code=400, detail="Basket is not ready to be sent")

@router.post("/baskets/{basket_id}/send", status_code=201)
async def send_basket(basket_id: int):
    raise HTTPException(status_code=400, detail="Basket is not ready to be sent")