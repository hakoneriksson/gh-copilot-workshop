from pydantic import BaseModel

class Urb(BaseModel):
    id: int
    name: str