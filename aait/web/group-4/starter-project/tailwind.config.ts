import type { Config } from 'tailwindcss'

const config: Config = {
  content: [
    './pages/**/*.{js,ts,jsx,tsx,mdx}',
    './components/**/*.{js,ts,jsx,tsx,mdx}',
    './app/**/*.{js,ts,jsx,tsx,mdx}',
],
  theme: {
    extend: {
      colors: {
        "primary-color": "#264FAD",
      },
      fontFamily:{
        'lato': ['Lato', 'sans-serif'],
        'nunito': ['Nunito', 'sans-serif'],
        'poppins': ['Poppins', 'sans-serif'],
        'inter': ['Inter', 'sans-serif'],
        'fira-code': ['Fira Code', 'monospace'],
        "montserrat": ['Montserrat', 'sans-serif'],
        "roboto": ['Roboto', 'sans-serif']
      },
      screens:{
        // Custom screen break point
        "lg-1": "1150px"
      }
    },
  },
  plugins: [],
}
export default config
