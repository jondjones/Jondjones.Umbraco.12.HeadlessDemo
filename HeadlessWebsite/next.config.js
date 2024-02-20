module.exports = {
    images: {
        remotePatterns: [
        {
            protocol: 'https',
            hostname: 'localhost',
            port: '44351',
        }],
        domains: ['localhost', 'media.giphy.com'],
        loader: "imgix",
        path: ""
    }
}