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
      fontFamily: {
        "poppins": ['Poppins', 'sans-serif'],
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
