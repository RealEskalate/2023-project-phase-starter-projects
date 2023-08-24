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
        "blue-purple": "#160041",
        "charcoal": "#363636",
        "dark-gray": "#424242",
        "medium-gray": "#7D7D7D",
        "light-gray": "#878593",
        "slate-blue": "#37474F",
        "dim-gray": "#565656",
        "smoke": "#FDFEFF",
        "lavender-gray": "#F6F6FC",
        "grayish-blue": "#878593",
        "grayish-brown": "#4D4A49",
        "dodger-blue": "#019CFA",
        "jet-black":"#242424",
        "gunmetal-gray":"#565656",
        "very-dark-gray" : "#0F0F0F"
      },
      fontFamily: {
        poppins: ['Poppins', 'sans-serif'],
        montserrat: ['Montserrat', 'sans-serif'],
        roboto: ['Roboto', 'sans-serif']
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
