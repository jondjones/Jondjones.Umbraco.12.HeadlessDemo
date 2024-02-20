describe("Homepage", () => {
    it("Loads", () => {
        cy.visit("/");
        cy.get("h1").should("be.visible");
    })
})