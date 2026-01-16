export function showPrompt(message) {
    return prompt(message, 'Type anything here');
}


export function showAlert(message) {
    alert(message);
}


export function ConfirmdeleteContact(message) {
    const response = confirm(message);

    if (response) {
        // User clicked OK
        console.log("Item deleted.");
        // Place your deletion logic here (e.g., an API call)
        return true;
    } else {
        // User clicked Cancel
        console.log("Deletion cancelled.");
        return false;
    }
}


export function renderGroupChart(data) {
    const selector = "#chart-container";
    const container = d3.select(selector);
    container.selectAll("*").remove();

    if (!data || data.length === 0) return;

    // Dimensions
    const margin = { top: 20, right: 40, bottom: 30, left: 100 };
    const width = document.querySelector(selector).offsetWidth - margin.left - margin.right;
    const height = (data.length * 45);

    const svg = container.append("svg")
        .attr("width", width + margin.left + margin.right)
        .attr("height", height + margin.top + margin.bottom)
        .append("g")
        .attr("transform", `translate(${margin.left},${margin.top})`);

    // Scales - using 'name' and 'value' from our C# DTO
    const x = d3.scaleLinear()
        .domain([0, d3.max(data, d => d.value)])
        .range([0, width]);

    const y = d3.scaleBand()
        .domain(data.map(d => d.name))
        .range([0, height])
        .padding(0.2);

    // Bars
    svg.selectAll("rect")
        .data(data)
        .join("rect")
        .attr("y", d => y(d.name))
        .attr("x", 0)
        .attr("width", d => x(d.value))
        .attr("height", y.bandwidth())
        .attr("fill", "#28a745") // Green theme
        .attr("rx", 4);

    // Labels
    svg.append("g")
        .call(d3.axisLeft(y).tickSize(0).tickPadding(10));

    svg.append("g")
        .attr("transform", `translate(0, ${height})`)
        .call(d3.axisBottom(x).ticks(Math.min(5, d3.max(data, d => d.value))));
}