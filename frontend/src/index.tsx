import { createRoot } from 'react-dom/client'
import './index.css'
import App from './app.tsx'
import { MemoryRouter } from 'react-router-dom'

createRoot(document.getElementById('root')!).render(
  <MemoryRouter>
    <App />
  </MemoryRouter>,
)
