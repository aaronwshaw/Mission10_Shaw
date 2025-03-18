import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react';

// What port it is coming from. Front end is running on port 3000
export default defineConfig({
  plugins: [react()],
  server: {
    port: 3000,
  },
});
