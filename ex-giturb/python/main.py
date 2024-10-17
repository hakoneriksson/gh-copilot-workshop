import uvicorn
from fastapi import FastAPI
from fastapi.responses import RedirectResponse
from contextlib import asynccontextmanager

from utils.urbs_seeder import seed_urbs
from endpoints.urbs import router as urb_router
from endpoints.baskets import router as basket_router

# seed urbs on app startup
@asynccontextmanager
async def lifespan(app: FastAPI):
    seed_urbs()
    yield

app = FastAPI(lifespan=lifespan)

app.include_router(urb_router)
app.include_router(basket_router)

@app.get("/", include_in_schema=False)
async def root_redirect_to_swagger():
    return RedirectResponse(url="/docs")


if __name__ == "__main__":
    uvicorn.run("main:app", host="0.0.0.0", port=8000, reload=True)
