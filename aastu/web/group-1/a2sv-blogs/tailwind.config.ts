import type { Config } from 'tailwindcss'

const config: Config = {
  content: [
    './src/pages/**/*.{js,ts,jsx,tsx,mdx}',
    './src/components/**/*.{js,ts,jsx,tsx,mdx}',
    './src/app/**/*.{js,ts,jsx,tsx,mdx}',
  ],
  theme: {
    extend: {
      fontFamily: {
        poppins: ['Poppins', 'sans-serif'],
        montserrat: ['Montserrat', 'sans-serif'],
        nunito: ['Nunito', 'sans-serif'],
        french: ['IM Fell French Canon', 'serif'],
      },
      colors: {
        primary: '#264FAD',
        secondary: '#5F0A87',
        "text-header" : {
          1: '#363636',
          2: '#424242',
        },
        'white': '#ffffff',
        'a2sv-blue': '#264FAD',
        'dark-blue': '#160041',
        'dark-text': '#424242',
        'light-text': '#7D7D7D',
        'bg-color':'#F6F6FC',
        'black-text':'#363636',
        'light blue': '#019cfa',
        'border-white': '#E6E6E6',
        'light-light-black': '#0F0F0F',
        'nav-black':'#565656',
        'nav-grey':"#3c3c3c",
        'dark-chocolate': '#4D4A49',
        'greyish-black':'#878593',
        "text-content" : "#7d7d7d"
      }
    },
  },
  plugins: [],
}
export default config
