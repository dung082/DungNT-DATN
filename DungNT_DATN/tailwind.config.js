/** @type {import('tailwindcss').Config} */
export default {
  content: ["./index.html", "./src/**/**/*.{js,ts,jsx,tsx}"],
  theme: {
    extend: {
      colors: {
        colorthemes: "#085BA4",
        white: "#fff",
        line: "#d3cfcf",
        success : "#5cb85c",
        error : "#f44336"
      },
    },
  },
  plugins: [],
};
